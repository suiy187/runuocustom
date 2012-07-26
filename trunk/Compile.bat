cd Server
SET DOTNET=C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727
SET PATH=%DOTNET%
csc.exe /win32icon:orb.ico /r:Ultima.dll /debug /nowarn:0618 /nologo /out:..\Orb_Server.exe /unsafe /recurse:*.cs
PAUSE
cd ..
title Orbsydia Server - Based on UO 2.2 SVN R25 - by Team Orbsydia
echo off
cls
Orb_Server.exe