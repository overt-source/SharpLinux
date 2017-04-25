@echo off
echo fucking - a high-level package manager for the CMDLinux Operating system
rem check for curl/wget
rem we need this across all binaries
if exist "%rootpath.shell%\lib\curl.exe" goto main
if exist "%rootpath.shell%\lib\wget.exe" goto main
if not exist "%rootpath.shell%\lib\curl.exe" goto liberror
if not exist "%rootpath.shell%\lib\wget.exe" goto liberror
:liberror
echo fucking: E: 1, in init.install, failed to locate network access libraries in /lib
goto:eof
:main
set /p fuckingsource.shell=< %rootpath.shell%\etc\fucking\source
echo fucking: using source %fuckingsource.shell%
set /p fucking.package.name=fucking: need package identifyer: 
if exist %rootpath.shell%\etc\fucking\packages\%fucking.package.name% (
goto install
)
if not exist %rootpath.shell%\etc\fucking\packages\%fucking.package.name% (
echo fucking: fatal: %fucking.package.name%: NOT A PACKAGE IDENTIFYER, OR NOT IN THE LOCAL DATABASE.
echo fucking: If you're sure it's there, do fucking-update to make sure we have the latest
echo fucking: packages.
echo fucking exited with error code: 2
)
goto:eof
