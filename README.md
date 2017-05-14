# SharpLinux: A linux-like operating system userspace for windows
###### Version 0.1-LEILU (beta)
## Welcoem to SharpLinux!
SharpLinux is an open-source, compact, and familiar linux-style command userspace for windows.
It was inspired by the reimplementations of GNU utilities and other things done by cygwin, etc. It may never (and will never) be as feature-complete, but it wasn't designed to be.
Note: source tree is in /usr/share/src to comply with the FJS.
## Things that work:
* the init binary
* The shell - /bin/tsh (if you can get it running without logging in).
* command detection
* application execution



## Things that don't:

* documentation files
* some form of a login system
* adding users
* basic user rights access
* basic filesystem commands
* parts of the package manager
* text editing (need to find nano for windows).
* removing users that you added (use rm-d for now).
* Everything else


## Build instructions:
Simply clone the repository, then run init from the repo's working dir.
Enjoy!