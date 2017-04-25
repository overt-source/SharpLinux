@echo off
rem CMDLinux kernel startup script.
rem THIS SCRIPT SHOULD NOT BE MODIFIED BY
rem PEOPLE WHO DON'T KNOW WHAT THEY'RE DOING!
echo STARTING CMDLinux (%processor_architecture%):%processor_revision%
echo on-line CPUs: %number_of_processors%
set rootpath.shell=%cd%
timeout /t 6 >> %rootpath.shell%\etc\bootlog
echo Welcome to CMDLinux!
echo CMDLinux %computername% 2.0.0(2.0.0/%processor_architecture%-windows-master) 2017-04-25 14:22 %processor_architecture% Cmdlinux...
set uname.shell=CMDLinux %computername% 2.0.0(2.0.0/pc-windows-master) 2017-04-25 14:22 %processor_architecture% Cmdlinux
echo TTY1 CMDLinux Login:
pause
call %rootpath.shell%\bin\login