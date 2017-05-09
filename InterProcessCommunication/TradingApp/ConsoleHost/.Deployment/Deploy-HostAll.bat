cd %1

del ..\..\Deploy\HostAll\*.* /F /Q		

xcopy ..\*.dll ..\..\Deploy\HostAll\ /Y /I
xcopy ..\ConsoleHost.exe* ..\..\Deploy\HostAll