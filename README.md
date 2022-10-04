# PowerPlanManager
## A small utility that changes Windows PowerPlan or PowerMode on depending on user input timeout or other parameters.


## How it works:
The software attempts to detect if the user is actually using the computer, and if not it changes the current Power Plan (or the newer Power Mode), and reverts it back whenever the user resumes using the pc.
There are 2 main methods of detecting user idle:
### 1. Mouse movement:
Detects mouse movement between each polling event.
### 2. Screensaver:
Detects if Windows is showing a screensaver.

It is also possible to prevent PPM from working if a given process is running (eg. when watching a movie).

## Installation:
Upon starting, PPM asks if it can copy itself to its folder in %appdata%, where it will work and save the log and preferences file.
A registry key is added for autostart.
No installer is provided or necessary, to uninstall just exit the program and delete the folder.

## FAQs:
# 1) Why did you make it?
I happen to leave my PC running all the time, and found out changing the Power Mode to Battery Saver prevents the CPU from spiking for random background tasks and the fans from spinning up during the night. This also helps conserve energy.

# 2) Why is it so ugly?
I'm using WinForms as i'm most familiar with it. You're welcome to contribute :)

# 3) Why is the code so ugly?
I made this software for my personal use and was done in a rush. You're welcome to contribute :)

## NOTICE:
This software works on my PC, running Windows 11. It might work on other versions of Windows, but i haven't tested it. It probably won't work for versions older than Windows 10. 
It also probably requires some form of .Net redistributable installed.
