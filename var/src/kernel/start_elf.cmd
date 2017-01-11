
@echo off
rem CMDLinux version 1.70 (beta) for MS Windows
timeout /t 1 > .\tmp/bit_bucket
color 19
timeout /t 1 > .\tmp/bit_bucket
color
echo graphics hardware detected and initialised...
del .\etc\bootlog
title CMDLinux
echo notice: initialised graphics... >> .\etc\bootlog
echo setting root path variable... >> .\etc\bootlog
set rootpath.shell=%cd%
echo done setting root path variable... >> .\etc\bootlog
echo setting uname variable... >> .\etc\bootlog
set uname.shell=cmdLinux localhost 1.7.0-00-finnbook #1-finnbook Wed Jan 11 21:12:26 NZST 2017 %processor_architecture% CMD/Linux
echo done setting uname variable... >> .\etc\bootlog
echo starting userspace... >> .\etc\bootlog
call .\bin\login