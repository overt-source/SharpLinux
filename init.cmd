@echo off
rem CMDLinux kernel startup script.
rem THIS SCRIPT SHOULD NOT BE MODIFIED BY
rem PEOPLE WHO DON'T KNOW WHAT THEY'RE DOING!
title CMDLinux starting...
set version.shell=2.2.1
set CompileTime.shell=2017-04-28 19:52
set buildid.shell=221
set build.shell=0005
echo STARTING CMDLinux (%processor_architecture%):%processor_revision%
echo on-line CPUs: %number_of_processors%
set rootpath.shell=%cd%
timeout /t 6 >> %rootpath.shell%\etc\bootlog
echo Welcome to CMDLinux!
echo CMDLinux %computername% %version.shell%(%buildid.shell%.%build.shell%/%processor_architecture%-windows-master) %CompileTime.shell%, %processor_architecture% Cmdlinux
set uname.shell=CMDLinux %computername% %version.shell%(%buildid.shell%.%build.shell%/%processor_architecture%-windows-master) %CompileTime.shell%, %processor_architecture% Cmdlinux
call %rootpath.shell%\bin\login