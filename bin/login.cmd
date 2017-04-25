@echo off
rem CMDLinux Login module version 1.0
echo login: determining hostname... >> "%rootpath.shell%\etc\bootlog"
set /p hostname.shell=< "%rootpath.shell%\etc\hostname"
echo login: hostname is %hostname.shell% >> "%rootpath.shell%\etc\bootlog"

color 17
cls
:username
echo ________________________________________________________________________________
echo CMDLinux LOGIN 
echo ________________________________________________________________________________
echo [ enter your user name to log in to %hostname.shell% ]
echo [ if you do not have a username, you can not log in (anon login disabled) ]
echo ENTER USERNAME (OK=enter cancel=^C)
set /p username.shell=:
if %username.shell% == adduser goto adduser
echo determining home directory for %username.shell%...
if exist "%rootpath.shell%\home\%username.shell%\.allowed_login" goto password
if not exist "%rootpath.shell%\home\%username.shell%\.allowed_login" goto notallowed
:password
cls
echo ________________________________________________________________________________
echo CMDLinux LOGIN 
echo ________________________________________________________________________________
echo %username.shell%, enter your password
set /p passwd.shell=:
set /p passwdcompare.shell=< "%rootpath.shell%\home\%username.shell%\.passwd"
if %passwd.shell% == %passwdcompare.shell% (goto loginscript ) else (goto wrongpass)

goto:eof
:notallowed
echo ________________________________________________________________________________
echo CMDLinux LOGIN 
echo ________________________________________________________________________________
echo Sorry, no such user '%username.shell%' (code 1)
timeout /t 3 > %rootpath.shell%\null
cls
goto:username
:loginscript
echo running /home/%username.shell%/.loginrc...
cls
call "%rootpath.shell%\home\%username.shell%\.loginrc.cmd"
goto:eof
:wrongpass
echo ________________________________________________________________________________
echo CMDLinux LOGIN 
echo ________________________________________________________________________________
echo access denied, please try again (code 2)
timeout /t 3 > %rootpath.shell%\null
cls
goto:password
:adduser
echo ________________________________________________________________________________
echo CMDLinux LOGIN 
echo ________________________________________________________________________________
echo sorry, you can't add users from the login window. Login as root first (code 3).
timeout /t 3 > %rootpath.shell%\null
cls
goto:username
