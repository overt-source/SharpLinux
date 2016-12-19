# cmdlinux
a minimal linux-style pseudo-OS written in windows batch and, where necesary, C#, using only open-source libraries as a backing
## run and build
clone, run start_elf from a command prompt. done
##warnings

* this is very minimal, shit might be broken
* fucking (the package manager) will look in /etc/fucking/source for it's root URL. You can change this if you want to use your own.

## general notes

*most packages will have mode parameters (E.G.: hostname has hostname-set). These parameters are appended to the package name without a space.

* spaced parameters or inputs are not supported at this time. All file inputs are specified in their own entry boxes.

##todo
*add true package management
*add the doc system
*make login system more secure
