#CMDLinux: A basic, linux-like operating system userspace for windows
## Welcoem to CMDLinux!
Cmdlinux is an open-source, compact, and familiar linux-style command userspace for windows.
CMDLinux was inspired by the reimplementations of GNU utilities and other things done by cygwin, etc.
## Things that work:
* The SH (esque) shell
* command detection
* application execution
* documentation files
* some form of a login system
* adding users
* primitive privilege seperation
* basic filesystem commands
* a launcher binary (select kernel file and root directory.)


## Things that don't:


* the package manager (currently a stub).
* text editing (need to find nano for windows).
* removing users that you added (use rm-d for now).
* Everything else


## Build instructions:
Simply clone the repository, then run claunch.exe with params kernel filename )default: \sbin\init) and root dir (default: %cd%) from a command line where the repo appeared. The default (root) password is bluebox, and the hostname is crossbar.
Enjoy!