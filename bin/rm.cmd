@echo off
set /p rm.shell=? 
if not exist %rm.shell% (
echo RM: %rm.shell%: no such file or directory
goto:eof
)
if not exist %rootpath.shell%%rm.shell% (
echo RM: %rm.shell%: no such file or directory
goto:eof
)

del /q %rm.shell%
del /q %rootpath.shell%%rm.shell%
