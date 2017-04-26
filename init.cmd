@echo off
rem CMDLinux kernel startup script.
rem THIS SCRIPT SHOULD NOT BE MODIFIED BY
rem PEOPLE WHO DON'T KNOW WHAT THEY'RE DOING!
title CMDLinux starting...
echo STARTING CMDLinux (%processor_architecture%):%processor_revision%
echo on-line CPUs: %number_of_processors%
set rootpath.shell=%cd%
timeout /t 6 >> %rootpath.shell%\etc\bootlog
echo Welcome to CMDLinux!
echo CMDLinux %computername% 2.1.0(2.1.0/%processor_architecture%-windows-master) 2017-04-26 16:43 %processor_architecture% Cmdlinux...
set uname.shell=CMDLinux %computername% 2.1.0(2.1.0/%processor_architecture%-windows-master) 2017-04-26 16:43 %processor_architecture% Cmdlinux...
echo TTY1 CMDLinux Login:
call %rootpath.shell%\bin\login