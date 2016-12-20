@echo off
echo fucking - a high-level package manager for the CMDLinux Operating system
rem check for curl/wget
if exist "%rootpath.shell%\lib\curl.exe" goto main
if exist "%rootpath.shell%\lib\wget.exe" goto main
if not exist "%rootpath.shell%\lib\curl.exe" goto liberror
if not exist "%rootpath.shell%\lib\wget.exe" goto liberror
:liberror
echo fucking: E: 1, in init, failed to locate network access libraries in /lib
goto:eof
:main
echo fucking: need an operation (like -install,-upgrade,-upgrade-all)

goto:eof
