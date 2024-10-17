# btw-exporter
Bill the Wizard's Proof of concept textfile exporter
for Windows 10/11. The project features both the source code
and an installer for a custom textfile metrics service
based on LibreHardwareLib and WinSW.

## btw-metrics
I created a unsigned innosetup installer for automating the
installation of the proof of concept. Download or read about how 
to build the project yourself at the links below:

[btw-metrics docs](btw-metrics/btw-metrics.md)

[Download installer for btw-metrics.exe](btw-metrics.exe)

## About Bill the Wizard
I am a System and Network Administrator that endeavors to be a programmer.
My specialties include Python, Shell scripting, Ansible automation, and
Debian Linux. I enjoy studying the art of programming, and I like
to put my learning to use.

Doing this project was an opportunity to learn more about C# programming,
how services work on Windows, and designing a software installer. I like
to learn by doing when it comes to technology, so I made this tool.

I spent my free time engineering this little project to get the ball rolling
at work on fixing Grafana dashboards for Windows 10/11. The problem is that
Windows reports nonsense in it's ThermalZone WMI interface. I tried to chase
down the reason why it's broken, but it seems like a case of things just breaking
and Microsoft not seeing the value in fixing it.

Maybe it has something to do with how most Windows machines are used. Most of the
time it's installed in someone's office, or on a gaming computer. Both of these
scenarios have the machine being used by primarily one user. If one person
is using a machine, they are almost certain to notice if it's overheating.

I want to be able to graph out system temperature on Windows, so I can explore
patterns in how my home computer is used. I can explore questions like: who drives
the system the hardest, or is the cooling in my home PC adequate?

I had a lot of fun making this small bit of software, and taught me a lot about how to 
tackle some tricky problems at work, so I am very excited to share this with the world.



