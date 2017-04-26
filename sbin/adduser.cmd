@echo off
echo Adding New user to %hostname.shell%
set /p adduser.username=Enter Unix Username:
set /p adduser.passwd=Enter Unix password:
set /p adduser.reenterpasswd=Enter Unix password again:
if %adduser.passwd%==%adduser.reenterpasswd% (
echo creating home directory for %adduser.username%...
mkdir %rootpath.shell%\home\%adduser.username%
echo Done.
echo copying files from /etc/skell...
copy %rootpath.shell%\etc\skell\.* %rootpath.shell%\home\%adduser.username% > %rootpath.shell%\tmp\bit_bucket
echo %adduser.passwd% > %rootpath.shell%\home\%adduser.username%\.passwd
echo the user ^(%adduser.username%^) added successfully.
goto:eof
)
echo passwords don't match.
