@echo off
rem CMDLinux kernel startup script.
rem THIS SCRIPT SHOULD NOT BE MODIFIED BY
rem PEOPLE WHO DON'T KNOW WHAT THEY'RE DOING!
title CMDLinux starting...
set version.shell=2.2.2
set CompileTime.shell=2017-05-01t14:39:15+12:00
set codename.shell=mariah
set buildid.shell=222
set build.shell=0001
echo STARTING CMDLinux (%processor_architecture%):%processor_revision%
echo on-line CPUs: %number_of_processors%
set rootpath.shell=%cd%
timeout /t 6 >> %rootpath.shell%\etc\bootlog
echo Welcome to CMDLinux!
echo CMDLinux %version.shell% %codename.shell%:(%buildid.shell%.%build.shell%/%processor_architecture%-windows-master) %CompileTime.shell%, %processor_architecture% Cmdlinux
set uname.shell=CMDLinux %version.shell% %codename.shell%:(%buildid.shell%.%build.shell%/%processor_architecture%-windows-master) %CompileTime.shell%, %processor_architecture% Cmdlinux
call %rootpath.shell%\bin\login