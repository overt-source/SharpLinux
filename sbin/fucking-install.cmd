@echo off
rem calls fucking(1) to install package
set /p package.install.shell=Fucking: enter package name to install: 
if %package.install.shell% == curl (
echo curl is already here, otherwise fucking wouldnt've started
echo curl: preinst
goto:eof
)
