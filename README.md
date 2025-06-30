# PowerPlanManager
Small utility to automatically switch power plans depending on running applications and user interaction, ideal for gaming laptops / desktop replacement where CPU boost is rarely needed but temperature and power usage if of concern during normal usage.

# How it works:
PowerPlanManager (PPM) creates 3 custom power plan schemes (PowerSaver, Balanced, Performance) and will switch between them depending on user interaction and running programs.
It is possible to assign running programs to force Balanced or Performance mode, otherwise PPM will switch to PowerSaver scheme if the user is idle for a customizable amount of seconds.
PPM will automatically switch to PowerSaver also if the system screensaver is running.

# Features:
Battery, Temperature or Performance focus depending on user needs:
- PowerSaver has HALF max CPU boost, to preserve battery.
- Balanced has NO CPU boost, to lower temperatures while maintaining reasonable performance.
- Performance has CPU boost enabled, for max performance.

Customizable unified screen, sleep and hybernate timeout values for the 3 power modes:
- PowerSaver has screen, sleep, hibernate timeouts.
- Balanced has screen timeout but sleep and hibernate are disabled.
- Performance has no timeouts: the computer and monitor will stay on as long as this scheme is active.

# Installation:
Upon starting, PPM asks if it can add the 3 custom power plans, which are required.
Upon starting, PPM asks if it can copy itself to its folder in %appdata%, where it will work and save the log and preferences file.
A registry key is added for autostart.
No installer is provided or necessary, to uninstall just exit the program and delete the folder in %appdata%.

# WARNING:
This software works on my laptop PC, running Windows 11. It probably won't work for versions older than Windows 10. 
It also probably requires some form of .Net redistributable installed.
