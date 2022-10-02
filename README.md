# PowerPlanManager
## A small utility that changes Windows power plan on the fly depending on user input.

## How it works:
The software detects if the user is actually using the computer, and if not is able to change the current Windows Power Plan (and revert it back whenever the user resumes using the pc).
There are 2 main methods of detecting user idle:
### 1. Mouse movement:
Detects mouse movement between each polling event.
### 2. Screensaver:
Detects if Windows is showing a screensaver.

It is also possible to prevent PPM from working if a given process is running (eg. when watching a movie).

## Installation:
Upon starting, PPM asks if it can copy itself to its folder in %appdata%, where it will work and save the log file.
A registry key is added for autostart.

The software does not have an installer at the moment.

