@echo off
echo fucking - a high-level package manager for the CMDLinux Operating system
:main
set /p fuckingsource.shell=< %rootpath.shell%\etc\fucking\source
echo fucking: using source %fuckingsource.shell%
echo Fucking: Fetching package indexes...
%rootpath.shell%\libexec\libwebget.module %fuckingsource.shell%/packages.tar %rootpath.shell%\etc\fucking\packages.tar
if %errorlevel% == 5 (
echo FUCKING: FATAL: INTERNET CONNECTION OR SERVER ERROR WHILE FETCHING PACKAGES.TAR FROM %fuckingsource.shell%
)
goto:eof
