cd %1

del ..\..\Deploy\Sales\*.* /F /Q		

xcopy ..\*.dll ..\..\Deploy\Sales\ /Y /I
xcopy ..\ConsoleHost.exe ..\..\Deploy\Sales
xcopy ConsoleHost.Sales.config ..\..\Deploy\Sales
rename ..\..\Deploy\Sales\ConsoleHost.sales.config ConsoleHost.exe.config

del ..\..\Deploy\Sales\Quotations.* /F /Q
del ..\..\Deploy\Sales\Portfolio.* /F /Q