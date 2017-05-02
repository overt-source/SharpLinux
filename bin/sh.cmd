@echo off
:entry
set /p command.shell=SH-2.3%shebang%
title %username.shell%@%hostname.shell% : %cd%
if %command.shell% == sh (
echo Can't spawn child with recursive parent.
goto entry
)
if %command.shell% == exit (
echo logout
color
title CMD.EXE
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
echo sorry, exec for %command.shell% not permitted: non-0 uid ^(try su?^)
goto entry
)
if exist "%rootpath.shell%\opt\%command.shell%\bin\%command.shell%.cmd" (
set did_do=1
call "%rootpath.shell%\opt\%command.shell%\bin\%command.shell%.cmd"
goto entry
)
echo SH: %command.shell%: command not found
goto entry