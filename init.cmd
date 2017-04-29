@echo off
rem CMDLinux kernel startup script.
rem THIS SCRIPT SHOULD NOT BE MODIFIED BY
rem PEOPLE WHO DON'T KNOW WHAT THEY'RE DOING!
title CMDLinux starting...
set version.shell=2.2.1
set CompileTime.shell=2017-04-29t20:46:31+12:00
set codename.shell=mariah
set buildid.shell=221
set build.shell=0006
echo STARTING CMDLinux (%processor_architecture%):%processor_revision%
echo on-line CPUs: %number_of_processors%
set rootpath.shell=%cd%
timeout /t 6 >> %rootpath.shell%\etc\bootlog
echo Welcome to CMDLinux!
echo CMDLinux %version.shell% %codename.shell%:(%buildid.shell%.%build.shell%/%processor_architecture%-windows-master) %CompileTime.shell%, %processor_architecture% Cmdlinux
set uname.shell=CMDLinux %version.shell% %codename.shell%:(%buildid.shell%.%build.shell%/%processor_architecture%-windows-master) %CompileTime.shell%, %processor_architecture% Cmdlinux
call %rootpath.shell%\bin\login