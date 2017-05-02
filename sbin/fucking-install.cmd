@echo off
echo fucking - a high-level package manager for the CMDLinux Operating system
rem check for libwebget
if exist "%rootpath.shell%\libexec\libwebget.module" goto main
if not exist "%rootpath.shell%\libexec\libwebget.module" goto liberror
:liberror
echo fucking: ERROR_NO_LIBRARYS - how are we going to access the internet?
goto:eof
:main
set /p fuckingsource.shell=< %rootpath.shell%\etc\fucking\source
echo fucking: using source %fuckingsource.shell%
set /p fucking.package.name=fucking: need package identifyer: 
if exist %rootpath.shell%\etc\fucking\packages\%fucking.package.name% (
goto install
)
if not exist %rootpath.shell%\etc\fucking\packages\%fucking.package.name% (
echo fucking: fatal: %fucking.package.name%: NOT A PACKAGE IDENTIFYER, OR NOT IN THE LOCAL DATABASE.
echo fucking: If you're sure it's there, do fucking-update to make sure we have the latest
echo fucking: packages.
echo fucking exited with error code: 2
goto:eof
)
:install
echo fucking: looking up package...
set /p fucking.package.version=<%rootpath.shell%\etc\fucking\packages\%fucking.package.name%\version.string
set /p fucking.package.author=<%rootpath.shell%\etc\fucking\packages\%fucking.package.name%\author.string
set /p fucking.package.description=<%rootpath.shell%\etc\fucking\packages\%fucking.package.name%\info.textblock
echo Fucking: package identifyed (%fucking.package.name%:%fucking.package.version%).
:choice
choice /d i /n /c ida /m "(I)nstall, (D)etails, (A)bort - (Install in 20 seconds)" /t 20
if %errorlevel%==1 (
goto:doinst
)
if %errorlevel%==2 (
echo Fucking: Package - %fucking.package.name%.
echo Fucking: version - %fucking.package.version%.
echo Fucking: maintainer - %fucking.package.author%.
echo Fucking: About:
echo %fucking.package.description%.
goto:choice
)
if %errorlevel%==3 (
echo Fucking: Package Installation Error
Echo Fucking: Package Manager Failed to install 1 package^(S^): %fucking.package.name% - code %errorlevel%.
echo FUCKING: ABORTED!
)
goto:eof
