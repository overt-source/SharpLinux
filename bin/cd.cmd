@echo off
set /p dir.shell=?
cd %rootpath.shell%\%dir.shell%
if not %errorlevel% == 1 goto:eof
echo CD: %dir.shell%: no such file or directory
