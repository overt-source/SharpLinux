@echo off
rem CMDLinux version 1.4 (beta) for MS Windows
timeout /t 1 > .\tmp\bit_bucket
color 19
timeout /t 1 > .\tmp\bit_bucket
color
echo graphics hardware detected and initialised...
del .\etc\bootlog
title CMDLinux
echo notice: initialised graphics... >> .\etc\bootlog
echo notice: kernel started (status  code %errorlevel%). printing messages to /etc/bootlog
echo checking hardware and devices... >> .\etc\bootlog
ping 1.1.1.1 -w 3194 -n 5 > .\tmp\bit_bucket
echo done checking hardware and devices... >> .\etc\bootlog
echo setting root path variable... >> .\etc\bootlog
set rootpath.shell=%cd%
echo done setting root path variable... >> .\etc\bootlog
echo setting uname variable... >> .\etc\bootlog
set uname.shell=cmdLinux localhost 1.6.0-00-finnbook #1-finnbook Tue Dec 20 16:14:02 NZST 2016 %processor_architecture% CMD/Linux
echo done setting uname variable... >> .\etc\bootlog
echo starting login process... >> .\etc\bootlog
call .\bin\login.cmd