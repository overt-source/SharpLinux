@echo off
rem CMDLinux Login module version 2.2
echo login: determining hostname... >> "%rootpath.shell%\etc\bootlog"
set /p hostname.shell=< "%rootpath.shell%\etc\hostname"
echo login: hostname is %hostname.shell% >> "%rootpath.shell%\etc\bootlog"

color 1f
cls
:username
echo TTY1 CMDLinux %hostname.shell%
set /p username.shell=Login: 
if %username.shell% == adduser goto adduser
echo reading password...
if %username.shell% == ..\etc\skell (
echo Bad Username.
goto:username)
if exist "%rootpath.shell%\home\%username.shell%\.allowed_login" goto password
if not exist "%rootpath.shell%\home\%username.shell%\.allowed_login" goto notallowed
:password
cls
set /p passwd.shell=Password: 
set /p passwdcompare.shell=< "%rootpath.shell%\home\%username.shell%\.passwd"
if %passwd.shell% == %passwdcompare.shell% (goto loginscript ) else (goto wrongpass)

goto:eof
:notallowed
goto:username
:loginscript
echo Welcome to CMDLinux.
cls
call "%rootpath.shell%\home\%username.shell%\.loginrc.cmd"
goto:eof
:wrongpass
echo Try Again.
goto:password
:adduser
echo Bad Username.
goto:username
