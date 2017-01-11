@echo off
:entry
set /p command.shell=%username.shell%@%hostname.shell%:%cd%%shebang%
if %command.shell% == sh (
echo Can't spawn child with recursive parent.
goto entry
)
if %command.shell% == exit (
echo logout
goto:eof
)
if %command.shell% == login (
echo sh: 'login': not login shell., logout maybe?
goto entry
)
if exist "%rootpath.shell%\bin\%command.shell%.exe" (
set did_do=1
call "%rootpath.shell%\bin\%command.shell%.exe"
goto entry
)
if exist "%rootpath.shell%\sbin\%command.shell%.exe" (
set did_do=1
if %username.shell%==root (
call "%rootpath.shell%\sbin\%command.shell%.exe"
)
echo not sufficient privilages: %command.shell% needs root.
goto entry
)
if exist "%rootpath.shell%\opt\%command.shell%\bin\%command.shell%.exe" (
set did_do=1
call "%rootpath.shell%\opt\%command.shell%\bin\%command.shell%.exe"
goto entry
)
echo %command.shell%: command not found
goto entry