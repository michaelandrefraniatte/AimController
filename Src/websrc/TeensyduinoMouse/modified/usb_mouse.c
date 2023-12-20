/* Teensyduino Core Library
 * http://www.pjrc.com/teensy/
 * Copyright (c) 2013 PJRC.COM, LLC.
 *
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the
 * "Software"), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish,
 * distribute, sublicense, and/or sell copies of the Software, and to
 * permit persons to whom the Software is furnished to do so, subject to
 * the following conditions:
 *
 * 1. The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 *
 * 2. If the Software is incorporated into a build system that allows
 * selection among a list of target devices, then similar target
 * devices manufactured by PJRC.COM must be included in the list of
 * target devices and selectable in the same manner.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS
 * BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN
 * ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
 * CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
 
// This code has been modified by Elm�

#include "usb_dev.h"
#include "usb_mouse.h"
#include "core_pins.h" // for yield()
#include "HardwareSerial.h"
#include <string.h>  // for memcpy()

#define min(a,b) ((a)<(b)?(a):(b))
#define LSB(n) (n & 255)
#define MSB(n) ((n >> 8) & 255)


#if defined(MOUSE_INTERFACE) || defined(TOUCH_INTERFACE) // See usb_desc.h
#if F_CPU >= 20000000

// Flags which buttons are currently pressed
uint8_t usb_mouse_buttons_state = 0;

// These values are in pixels:
static uint32_t usb_mouse_pix_width    = 0;     // e.g. 1024 = 1024 pixels
static uint32_t usb_mouse_pix_height   = 0;     // e.g.  768 =  768 pixels
// These values are in percent multiplied with 100:
static uint32_t usb_mouse_pct_pos_x    = 5000;  // e.g. 5000 = 50.00% of screen width
static uint32_t usb_mouse_pct_pos_y    = 5000;  // e.g. 1550 = 15.50% of screen height
static uint32_t usb_mouse_pct_offset_x = 0;     // e.g.  750 =  7.50% of screen width
static uint32_t usb_mouse_pct_offset_y = 0;     // e.g. 1000 = 10.00% of screen height
static uint32_t usb_mouse_pct_width    = 10000; // e.g. 8500 = 85.00% of screen width
static uint32_t usb_mouse_pct_height   = 10000; // e.g. 9000 = 90.00% of screen height


// Maximum number of transmit packets to queue so we don't starve other endpoints for memory
#define TX_PACKET_LIMIT 3

static uint8_t transmit_previous_timeout=0;

// When the PC isn't listening, how long do we wait before discarding data?
#define TX_TIMEOUT_MSEC 30
#if F_CPU == 256000000
  #define TX_TIMEOUT (TX_TIMEOUT_MSEC * 1706)
#elif F_CPU == 240000000
  #define TX_TIMEOUT (TX_TIMEOUT_MSEC * 1600)
#elif F_CPU == 216000000
  #define TX_TIMEOUT (TX_TIMEOUT_MSEC * 1440)
#elif F_CPU == 192000000
  #define TX_TIMEOUT (TX_TIMEOUT_MSEC * 1280)
#elif F_CPU == 180000000
  #define TX_TIMEOUT (TX_TIMEOUT_MSEC * 1200)
#elif F_CPU == 168000000
  #define TX_TIMEOUT (TX_TIMEOUT_MSEC * 1100)
#elif F_CPU == 144000000
  #define TX_TIMEOUT (TX_TIMEOUT_MSEC * 932)
#elif F_CPU == 120000000
  #define TX_TIMEOUT (TX_TIMEOUT_MSEC * 764)
#elif F_CPU == 96000000
  #define TX_TIMEOUT (TX_TIMEOUT_MSEC * 596)
#elif F_CPU == 72000000
  #define TX_TIMEOUT (TX_TIMEOUT_MSEC * 512)
#elif F_CPU == 48000000
  #define TX_TIMEOUT (TX_TIMEOUT_MSEC * 428)
#elif F_CPU == 24000000
  #define TX_TIMEOUT (TX_TIMEOUT_MSEC * 262)
#endif

// endpoint = MOUSE_ENDPOINT -> send to the mouse endpoint
// endpoint = TOUCH_ENDPOINT -> send to the touchscreen endpoint (see usb_desc.c)
// x,y = relative coordinates for mouse movement
bool usb_mouse_send_packet(uint32_t endpoint, uint16_t x, uint16_t y, uint8_t wheel)
{    
    uint32_t wait_count=0;
    usb_packet_t *tx_packet;

    while (1) 
    {
        if (!usb_configuration) 
        {
            return false;
        }
        if (usb_tx_packet_count(endpoint) < TX_PACKET_LIMIT) 
        {
            tx_packet = usb_malloc();
            if (tx_packet) break;
        }
        if (++wait_count > TX_TIMEOUT || transmit_previous_timeout) 
        {
            transmit_previous_timeout = 1;
            return false;
        }
        yield();
    }
    
    transmit_previous_timeout = 0;    
       
    int p=0;
    if (endpoint == TOUCH_ENDPOINT) 
    {
		#if TOUCH_DEVICE == 2
			tx_packet->buf[p++] =  1; // contact count      (one finger is currently touching the screen)
			tx_packet->buf[p++] = 42; // contact identifier (may be any value)
		#endif
	
        tx_packet->buf[p++] = (usb_mouse_buttons_state & TOUCH_FINGER) ? 3 : 2;  // bit 0 = Finger up/down, bit 1 = In Range
        tx_packet->buf[p++] = LSB(usb_mouse_pct_pos_x);
        tx_packet->buf[p++] = MSB(usb_mouse_pct_pos_x);
        tx_packet->buf[p++] = LSB(usb_mouse_pct_pos_y); // absolute coordinates = percent value * 100 (0 ... 10000)
        tx_packet->buf[p++] = MSB(usb_mouse_pct_pos_y);
        tx_packet->len = p;
    }
	
    if (endpoint == MOUSE_ENDPOINT)
    {
        tx_packet->buf[p++] = (usb_mouse_buttons_state & MOUSE_ALL); // bit 0 = LEFT, bit 1 = RIGHT, bit 2 = MIDDLE button
        tx_packet->buf[p++] = LSB(x);  
        tx_packet->buf[p++] = MSB(x);
        tx_packet->buf[p++] = LSB(y); // relative coordinates (-32767 ... +32767)
        tx_packet->buf[p++] = MSB(y);
        tx_packet->buf[p++] = wheel;
        tx_packet->len = p;        
    }

    usb_tx(endpoint, tx_packet);
    return true;
}

bool usb_mouse_buttons(uint8_t left, uint8_t middle, uint8_t right, uint8_t touch)
{
    uint8_t mask = 0;
    if (left)   mask |= MOUSE_LEFT;
    if (middle) mask |= MOUSE_MIDDLE;
    if (right)  mask |= MOUSE_RIGHT;
    if (touch)  mask |= TOUCH_FINGER;
    
    uint8_t mouseChanged = (usb_mouse_buttons_state & MOUSE_ALL) != (mask & MOUSE_ALL);
    uint8_t touchChanged = (usb_mouse_buttons_state & TOUCH_ALL) != (mask & TOUCH_ALL);
    
    usb_mouse_buttons_state = mask;
    
    if (mouseChanged) 
    {
        if (!usb_mouse_send_packet(MOUSE_ENDPOINT, 0, 0, 0))
            return false;
    }
    if (touchChanged) 
    {
        if (!usb_mouse_send_packet(TOUCH_ENDPOINT, 0, 0, 0))
            return false;
    }
    return true;
}

bool usb_mouse_move(int16_t x, int16_t y, int8_t wheel)
{
    return usb_mouse_send_packet(MOUSE_ENDPOINT, x, y, wheel);
}

bool usb_mouse_position(uint32_t x, uint32_t y)
{
    if (usb_mouse_pix_width > 0 && usb_mouse_pix_height > 0)
    {
        // Convert pixel --> percent * 100 with margin correction
        x = usb_mouse_pct_offset_x + (usb_mouse_pct_width  * x) / usb_mouse_pix_width;
        y = usb_mouse_pct_offset_y + (usb_mouse_pct_height * y) / usb_mouse_pix_height;
    }

    // Send absolute screen position in percent * 100 (values from 0 to 10000)    
    usb_mouse_pct_pos_x = min(x, 10000);
    usb_mouse_pct_pos_y = min(y, 10000);
    
    return usb_mouse_send_packet(TOUCH_ENDPOINT, 0, 0, 0);
}

void usb_mouse_screen_size(uint32_t widthPixel, uint32_t heightPixel, 
                           uint32_t marginLeft, uint32_t marginTop, uint32_t marginRight, uint32_t marginBottom)
{
    // in pixel
    usb_mouse_pix_width    = widthPixel;
    usb_mouse_pix_height   = heightPixel;
    // in percent * 100
    usb_mouse_pct_offset_x = marginLeft;
    usb_mouse_pct_offset_y = marginTop;
    usb_mouse_pct_width    = marginRight  - marginLeft;
    usb_mouse_pct_height   = marginBottom - marginTop;
}
    
#endif // F_CPU
#endif // MOUSE_INTERFACE || TOUCH_INTERFACE
