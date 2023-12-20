[Unlicense]: http://unlicense.org/
[Teensy]: http://www.pjrc.com/teensy/
[WiiChuck]: https://code.google.com/p/wiichuck/
[Nunchucky]: https://www.adafruit.com/products/345
[WiiChuck Adapter]: https://www.sparkfun.com/products/9281
[Teensyduino]: http://www.pjrc.com/teensy/teensyduino.html
[Youtube video]: https://www.youtube.com/watch?v=wR43tIJpoGE

# WiiChuckMouse

This code lets you use a Wii Nunchuck controller as a usb mouse by
utilizing the [Teensy][] board's usb device emulation capabilities.

Here's a [Youtube video][] of it in action.

### Hardware Requirements
* A [Teensy][] board
* A Wii Nunchuck breakout board (e.g. [Nunchucky][] or [WiiChuck Adapter][])

The current code assumes that power (+ or 3.3v) and ground (GND) are
both soldered directly to the Teensy board's power (VCC) and ground
(GND) pins. If not, it's a simple fix: change the `chuck.init(0,0)`
call in `setup()` to `chuck.init(VCC,GND)` where VCC and GND are the
pins on the Teensy where you soldered power and ground. (Just to be
safe, I put a 3.3v regulator between the Teensy and the WiiChuck
because the WiiChuck is designed to run at 3.3v and running at the 5v
of my Teensy 2.0 might (probably won't) damage it over time).

I have `clock` (`clk`/`c`) soldered to `D0` and `data` (`d`) soldered
to `D1` on the Teensy.

### Software Requirements
* [Teensyduino][] (Arduino software with Teensy add-ons)
* [WiiChuck][] Arduino library

You'll need to download and import the WiiChuck library so that this
code can `include <Wiichuck.h>`. Should be as easy as downloading the
zip and then selecting `sketch` -> `import library` -> `add library`
in the Teensyduino software. This code assumes you're using the
Teensyduino add-ons for Arduino so that things like `Mouse` exist
automatically (as the Teensy can emulate a mouse).

### Controls
* Accelerometer = mouse move
* Z = left click
* C = right click
* Joystick Y-axis = scroll wheel
* Holding Z+C for ~3 seconds will disable the wiichuck so that you
  can set it down and type or whatever. Holding Z+C again will
  re-enable the wiichuck.


Unfortunately, I couldn't find a way to do horizontal scrolling with
the Teensy. I also couldn't think of a way to incorporate
middle-click. The mouse movement is also a little slow/laggy
currently.

### License
Copyright (C) 2014  Sean Hickey (Wisellama)

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.


