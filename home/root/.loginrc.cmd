@echo off
rem in here (.loginrc) you can set
rem variables, your shell, etc
rem see doc loginrc for more info.

set shell=sh
set shebang=#
cd %rootpath.shell%\home\%username.shell%\
set command.shell=undefined
call "%rootpath.shell%\bin\%shell%.cmd"
