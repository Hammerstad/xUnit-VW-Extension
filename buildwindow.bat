@echo off

cinst scriptcs -y 1> nul
setlocal
cd tools

%windir%\SysWoW64\cmd.exe /C scriptcs build.csx -- %*
