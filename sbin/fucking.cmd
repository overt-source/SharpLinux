@echo off
echo fucking - a high-level package manager for the CMDLinux Operating system
:main
set /p fuckingsource.shell=< %rootpath.shell%\etc\fucking\source
echo fucking: using source %fuckingsource.shell%
echo fucking: need an operation (like -install,-upgrade,-upgrade-all)
echo fucking: check doc fucking for a list of appropriate commands

goto:eof
