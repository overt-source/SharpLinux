@echo off
set /p copyfrom.shell=Copy From?
set /p copyto.shell=Copy to?
copy %copyfrom.shell% %copyto.shell%  1> %rootpath.shell%\null2> %rootpath.shell%\tmp\bit_bucket
del %rootpath.shell%\null 2> %rootpath.shell%\tmp\bit_bucket

if not errorlevel == 1 goto:eof
set /p tmp.shell=< %rootpath%\tmp\bit_bucket
echo failed to copy %copyfrom% to %copyto%: %tmp.shell%