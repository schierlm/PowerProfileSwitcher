PowerProfileSwitcher
====================

(c) 2015 Michael Schierl


Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is furnished
to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


Introduction
------------

Lenovo/IBM includes (as part of their ThinkVantage program) a small utiltity
for ThinkPad notebooks, where a context menu allows to power down the screen
and quickly switch between power profiles (all of them, not just 3 recent
ones).

As this tool does not work in Windows 10 any longer, I decided to build my own
replacement - and make it better.

In addition to power down the screen it can also start the screensaver, and
it can disable screen blanking and suspend mode independent from the selected
power profile.


Requirements
------------

VBoxTextGrab requires the .NET Framework Version 4 (or above) to run. As
Windows 10 includes the .NET Framework 4.6, it works there without any issues.

To compile the source code yourself, you will need Microsoft Visual Studio
2015 Community (or higher).
