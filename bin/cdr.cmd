@echo off
set /p dir.shell=(RELATIVE)?
cd %cd%\%dir.shell%
if not %errorlevel% == 1 goto:eof
echo CDR: %dir.shell%: no such file or directory.
