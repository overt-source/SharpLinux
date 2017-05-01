@echo off
rem in here (.loginrc) you can set
rem variables, your shell, etc
rem see doc loginrc for more info.

set shell=sh
set shebang=#
cd %rootpath.shell%\home\%username.shell%\
set command.shell=undefined
echo (_)(_)(_)(_)(_)(_)(_)(_)(_)(_)
echo CMDLINUX version %version.shell% %codename.shell% compiled on %compiletime.shell%
echo (_)(_)(_)(_)(_)(_)(_)(_)(_)(_)
echo THIS SOFTWARE IS published UNDER THE GNU GENERAL PUBLIC LICENSE VERSION 2 AND IS COPYRIGHT (C) 2017 FINN TURNER AND CONTRIBUTERS. SEE /LICENCE FOR MORE INFORMATION.
call "%rootpath.shell%\bin\%shell%"
