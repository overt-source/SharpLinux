@echo off
set /p dir.shell=Move to?
cd %rootpath.shell%%dir.shell% 2> %rootpath.shell%\tmp\bit_bucket
if not %errorlevel% == 1 goto:eof
echo failed to move to %dir.shell%
