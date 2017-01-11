@echo off
set /p movefrom.shell=Move From?
set /p moveto.shell=Move to?
move %movefrom.shell% %moveto.shell%  1> %rootpath.shell%\null2> %rootpath.shell%\tmp\bit_bucket
del %rootpath.shell%\null 2> %rootpath.shell%\tmp\bit_bucket

if not errorlevel == 1 goto:eof
set /p tmp.shell=< %rootpath%\tmp\bit_bucket
echo failed to move %copyfrom% to %copyto%: %tmp.shell%