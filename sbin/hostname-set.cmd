@echo off
if %username.shell% == root (
goto:set
)
if not %username.shell% == root (
goto:privs
)
:privs
echo failed to lock /etc/hostname (you are %hostname.shell%, not root)
goto:eof
:set
echo Changing hostname for %hostname.shell%
set /p temp_host1=Enter New Unix Hostname:
echo setting Hostname to %temp_host1%

echo %temp_host1% > %rootpath.shell%\etc\hostname
echo Hostname updated. Changes will take effect on next system restart.
goto:eof
