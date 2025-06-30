# PowerPlanManager
A small utility to automatically switch windows PowerPlans depending on running applications and user interaction, ideal for gaming laptops / desktop replacement where CPU boost is rarely needed but temperature and power usage if of concern during normal usage.
It is possible to assign running programs to automatically switch to Balanced or Performance mode when they are running, otherwise the software will switch to PowerSaver mode if the user is idle for a customizable amount of seconds.
It will automatically switch to PowerSaver also if the system screensaver is running.
It is now possible to skip installation of default PowerPlans and select custom ones.

The default (now optional) PowerPlans when installed have the following values:

# PowerSaver
- has 50% max CPU frequency, to preserve battery.
- screen timeout enabled.
- sleep timeout enabled.
- (optional) manual hybernate after a set timeout, bypassing windows hybrid standby.

# Balanced
- has 100% max CPU frequency, but CPU boost disabled, to lower temperatures while maintaining reasonable performance.
- screen timeout
- NO sleep timeout
- NO manual hybernate timeout.

# Performance
- has no limits on cpu frequency and CPU boost enabled, for max performance.
- NO screen timeout
- NO sleep timeout
- NO manual hybernation timeout
- the computer and monitor will stay on as long as this scheme is active.

# Installation:
On first start the program ask to copy itself to %LocalAppData%\ElioSoft, where it will work and save the log and preferences file.
It will also ask to install 3 managed PowerPlans to use for the different modes (PowerSaver, Balanced, Performance). This step is now optional.
A registry key is added for autostart.
No installer is provided or necessary, to uninstall just exit the program and delete the folder in %LocalAppData%\ElioSoft.

# Disclaimer:
The software is provided “as is," and you use the software at your own risk.
It works on my laptop with AMD CPU and Windows 11. It probably won't work for versions older than Windows 10. 
It also probably requires some form of .Net redistributable installed.
