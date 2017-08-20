@echo off
echo More IP addresses:
ipconfig | find "IPv4" & hostname
pause > NUL