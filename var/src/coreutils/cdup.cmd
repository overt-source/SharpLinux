@echo off
if not %cd% == %rootpath.shell% (
cd ..
goto:eof
)
echo already at /
