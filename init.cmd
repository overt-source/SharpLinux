@echo off
rem CMDLinux kernel startup script.
rem THIS SCRIPT SHOULD NOT BE MODIFIED BY
rem PEOPLE WHO DON'T KNOW WHAT THEY'RE DOING!
title CMDLinux starting...
set version.shell=2.2.3
set CompileTime.shell=2017-05-02t14:42:03+12:00
set codename.shell=mariah
set buildid.shell=223
set build.shell=15
echo STARTING CMDLinux (%processor_architecture%):%processor_revision%
echo on-line CPUs: %number_of_processors%
if exist C:\Program Files\Git\usr\bin\tar.exe (
set rootpath.shell=%cd%
timeout /t 6 >> %rootpath.shell%\etc\bootlog
echo Welcome to CMDLinux!
echo CMDLinux %version.shell% %codename.shell%:(%buildid.shell%.%build.shell%/%processor_architecture%-windows-master) %CompileTime.shell%, %processor_architecture% Cmdlinux
set uname.shell=CMDLinux %version.shell% %codename.shell%:(%buildid.shell%.%build.shell%/%processor_architecture%-windows-master) %CompileTime.shell%, %processor_architecture% Cmdlinux
call %rootpath.shell%\bin\login
goto:eof
)
echo FATAL: GIT AND GNU COREUTILS NOT FOUND!
echo CMDLINUX IS EXITING...
goto:eof
