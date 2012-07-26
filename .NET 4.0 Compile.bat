cd Server
SET DOTNET=C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319
SET PATH=%DOTNET%
csc.exe /win32icon:orb.ico /r:Ultima.dll /debug /nowarn:0618 /nologo /out:..\Orb_Server.exe /optimize /unsafe /recurse:*.cs /define:Framework_4_0
PAUSE
cd ..
title Orbsydia Server - Based on UO 2.2 SVN R25 & .Net 4.0 - by Team Orbsydia
echo off
cls
Orb_Server.exe