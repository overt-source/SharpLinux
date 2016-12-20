@echo off
set /p dir.shell=Move to?
cd %dir.shell% 2> %rootpath.shell%\tmp\bit_bhcket
if not %errorlevel% == 1 goto:eof
echo failed to move to %dir.shell%
