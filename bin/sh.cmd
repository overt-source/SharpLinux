@echo off
:entry
set /p command.shell=%username.shell%@%hostname.shell%:%cd%%shebang%
title %username.shell%@%hostname.shell% : %cd%
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
if exist "%rootpath.shell%\bin\%command.shell%.cmd" (
set did_do=1
call "%rootpath.shell%\bin\%command.shell%.cmd"
goto entry
)
if exist "%rootpath.shell%\sbin\%command.shell%.cmd" (
set did_do=1
if %username.shell%==root (
call "%rootpath.shell%\sbin\%command.shell%.cmd"
goto entry
)
echo sorry, NoExec for %command.shell%: not root
goto entry
)
if exist "%rootpath.shell%\opt\%command.shell%\bin\%command.shell%.cmd" (
set did_do=1
call "%rootpath.shell%\opt\%command.shell%\bin\%command.shell%.cmd"
goto entry
)
echo %command.shell%: command not found
goto entry