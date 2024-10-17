# btw-metrics
Monitoring systm temperature is a good thing, and Windows doesn't make finding
out that information easy. btw-metrics makes beautiful dashboards about temperature
on Windows possible, for very little RAM.

btw-metrics is a Proof-of-Concept for a custom textfile exporter to run alongside
windows-exporter. The project leverages LibreHardwareLib and WinSW to export CPU 
temperature as a textfile for windows-exporter.

Windows-exporter has a module called "thermalzone" which should report
system temperature information, but Microsoft's WMI doesn't appear to be capable of
this function in 2024.

It's strange that is such a hard ask, but Windows is a great Gaming platform nonetheless.

LibreHardwareLib the library from the Libre Hardware Monitor project. The Libre
Harware Monitor is a fork of Open Hardware Monitor. The GUI hardware monitor program
takes up a bit of RAM. It's not too bad, but kind of a waste for something that I
never feel compelled to open.

btw-metrics adds CPU metrics to windows-exporter for about 7.5Mib of RAM. Most of
which is just WinSW.

# Examples: To be continued after I setup a test project for that...

# Installation
This project contains the source code for the Proof-of-Concept along with an installer.
The installer includes WinSW as a dependency package and includes the necessary libraries
from Libre Hardware Monitor. The installation process is as-expected aside from the scary
security warning.

Just download btw-metrics.exe as administrator, navigate the security prompt, and so on.
I could have just packaged a .zip folder and powershell script, but I don't want to
explain all that to anyone who might have a use case for this project.

# Want to build it yourself?
If you want to build the package yourself, it shouldn't be too hard to work out how to build
btw-metrics.exe since I provide the solution file. You'll need to add the LibreHardwareLib
Nuget package in order to build.

Want to add more features? Go ahead and fork this project. Good ideas for extending this are
tracking which computer has someone logged-in. I would have added that feature here, but
Windows Home makes reporting on those facts challenging. At work, I accomplish this with
some manipulation of the output from `quser`.

I drop a WinSW binary into the bin folder contents Visual Studio generates, rename the WinSW
binary TextfileMetrics.exe, and I build the installer using the Inno Setup compiler. 
The btw-metrics.iss file defines how I compiled the installer. 

# What does the installer do?
The installer extracts the compiled software to `C:\Program Files\btw-metrics`. The installer
runs the commands that create and startup a service called "TextfileMetrics". The service
will start up automatically wih Windows, so you can set it and forget it.

When you uninstall btw-metrics, the service is stopped and removed,  the software is deleted from
it's folder in Program Files. By default, uninstall leaves the folder and the log file from
WinSW.

Aside from the security pop-up, I impressed myself with how the installer worked out.

