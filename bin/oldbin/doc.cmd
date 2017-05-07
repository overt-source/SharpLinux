@echo off
set /p docfile.shell=Get Documentation on What? 
if %docfile.shell% == ^* (
echo "can't show all docfiles (ls /var/help/doc instead?)"
goto:eof
)
if exist %rootpath.shell%\var\help\doc\%docfile.shell%.document (
type %rootpath.shell%\var\help\doc\%docfile.shell%.document|more
goto:eof
)
echo Sorry, no docfile matching %docfile.shell%