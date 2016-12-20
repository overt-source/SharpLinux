@echo off
set /p rm.shell=remove which? 
if not exist %rm.shell% (
echo "failed to remove: %rm.shell% - does it exist?"
goto:eof
)

del /q %rm.shell% 2> %rootpath.shell%\tmp\bit_bucket
del /q %rootpath.shell%%rm.shell% 2> %rootpath.shell%\tmp\bit_bucket
