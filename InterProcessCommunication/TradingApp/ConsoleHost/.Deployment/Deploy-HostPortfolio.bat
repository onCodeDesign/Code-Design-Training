cd %1

del ..\..\Deploy\Portfolio\*.* /F /Q		

xcopy ..\*.dll ..\..\Deploy\Portfolio\ /Y /I
xcopy ..\ConsoleHost.exe ..\..\Deploy\Portfolio
xcopy ConsoleHost.Portfolio.config ..\..\Deploy\Portfolio
rename ..\..\Deploy\Portfolio\ConsoleHost.portfolio.config ConsoleHost.exe.config

del ..\..\Deploy\Portfolio\Quotations.* /F /Q
del ..\..\Deploy\Portfolio\Sales.* /F /Q