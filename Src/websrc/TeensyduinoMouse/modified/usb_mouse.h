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
 
#ifndef USBmouse_h_
#define USBmouse_h_

#include "usb_desc.h"

#if defined(MOUSE_INTERFACE) || defined(TOUCH_INTERFACE)

#include <inttypes.h>
#include <stdbool.h> // declares bool, true, false which normally exist only in C++ but not in C.

// C language implementation
#ifdef __cplusplus
extern "C" {
#endif

// forward declarations
void usb_mouse_screen_size(uint32_t widthPixel, uint32_t heightPixel, uint32_t marginLeft, uint32_t marginTop, uint32_t marginRight, uint32_t marginBottom);
bool usb_mouse_buttons(uint8_t left, uint8_t middle, uint8_t right, uint8_t touch);
bool usb_mouse_move(int16_t x, int16_t y, int8_t wheel);
bool usb_mouse_position(uint32_t x, uint32_t y);
extern uint8_t usb_mouse_buttons_state;
#ifdef __cplusplus
}
#endif

// Button definitions
#define MOUSE_LEFT   1 // left mouse button
#define MOUSE_MIDDLE 4 // middle mouse button
#define MOUSE_RIGHT  2 // right mouse button
#define TOUCH_FINGER 8 // a "touch" with the finger on a touch screen

#define MOUSE_ALL   (MOUSE_LEFT | MOUSE_RIGHT | MOUSE_MIDDLE)
#define TOUCH_ALL   (TOUCH_FINGER)
#define BUTTON_ALL  (MOUSE_ALL | TOUCH_ALL)

// C++ interface
#ifdef __cplusplus
class usb_mouse_class
{
public:
    void begin(void) { }
    void end(void)   { }
    
    // Calling this function is optional.
    // If you call this function, all values passed to Mouse.moveTo() are screen coordinates in pixels.
    // Example: Mouse.moveTo(1024, 768) moves the mouse to the bottom/right corner of a screen with the resolution 1024x768 pixels.
    // If you never call this function, all values passed to Mouse.moveTo() are values in percent of the screen width/height multiplied with 100.
    // Example: Mouse.moveTo(10000, 10000) moves the mouse to the bottom/right corner (100%, 100%) of a screen of ANY resolution.
    // widthPixel and heightPixel are the screen size in pixels.
    // Apple Macintosh puts a border of 7.5% around the usable area:
    // For MAC call: usb_mouse_screen_size(1024, 768, 750, 750, 9250, 9250);  // 7.50%, 7.50%, 100.00%-7.50%, 100.00%-7.50%
    // See http://lists.apple.com/archives/usb/2011/Jun/msg00032.html
    // Some Linux destributions have bugs that require their individual correction values.
    void screenSize(uint16_t widthPixel,   uint16_t heightPixel, // in pixel
                    uint16_t marginLeft=0, uint16_t marginTop=0, uint16_t marginRight=10000, uint16_t marginBottom=10000) // in percent * 100
    {
        usb_mouse_screen_size(widthPixel, heightPixel, marginLeft, marginTop, marginRight, marginBottom);
    }

    // The Linux X11 server is full of bugs. It works only correctly with a mouse that declares ONLY relative movement.
    // If a HID mouse declares both: relative and absolute or only absolute movement it works on some Linux computers but on others not.
    // This function can be used to move the mouse relatively but this functionality is completely useless if you try
    // to position the mouse exactly at a specific coordinate because it depends on the mouse configuration how many pixels the mouse is moved.
    // If you pass here x=100 and y=0 this does NOT mean that the mouse will move 100 pixels to the right on the screen!
    // Additionally if mouse enhancement is enabled in Control Panel all becomes worse.
    // Use this function only to move the mouse wheel and set x, y = 0.
    // To position the mouse exactly with absolute coordinates use Mouse.moveTo() instead which uses the exact touch screen interface.
    bool move(int8_t x, int8_t y, int8_t wheel=0) 
    { 
        return usb_mouse_move(x, y, wheel); 
    }
    
    // Positions the mouse at exact absolute coordinates via touch screen HID device.
    // The coordinates must be passed in percent or in pixels. See comment of screenSize().
    bool moveTo(uint16_t x, uint16_t y) 
    { 
        return usb_mouse_position(x, y); 
    }
    
    bool click(uint8_t button = MOUSE_LEFT) 
    {
        usb_mouse_buttons_state = button;
        if (!usb_mouse_move(0, 0, 0))
            return false;
        
        usb_mouse_buttons_state = 0;
        if (!usb_mouse_move(0, 0, 0))
            return false;
        
        return true;
    }

    // Move the mouse wheel
    bool scroll(int8_t wheel) 
    { 
        return usb_mouse_move(0, 0, wheel); 
    }
    
    // Set the state of the mouse buttons and the touch screen finger. 
    // To create a "click", 2 calls are needed, one to push the button down and the second to release it.
    bool set_buttons(uint8_t left, uint8_t middle=0, uint8_t right=0, uint8_t touch=0) 
    {
        return usb_mouse_buttons(left, middle, right, touch);
    }
    
    bool press(uint8_t b = MOUSE_LEFT) 
    {
        uint8_t buttons = usb_mouse_buttons_state | (b & BUTTON_ALL);
        if (buttons == usb_mouse_buttons_state) 
            return true;
        
        usb_mouse_buttons_state = buttons;
        return usb_mouse_move(0, 0, 0);
    }
    
    bool release(uint8_t b = MOUSE_LEFT) 
    {
        uint8_t buttons = usb_mouse_buttons_state & ~(b & BUTTON_ALL);
        if (buttons == usb_mouse_buttons_state) 
            return true;
        
        usb_mouse_buttons_state = buttons;
        return usb_mouse_move(0, 0, 0);
    }
    
    bool isPressed(uint8_t b = BUTTON_ALL) 
    {
        return ((usb_mouse_buttons_state & (b & BUTTON_ALL)) != 0);
    }
};
extern usb_mouse_class Mouse;

#endif // __cplusplus

#endif // MOUSE_INTERFACE

#endif // USBmouse_h_
