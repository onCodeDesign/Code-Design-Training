cd %1

del ..\..\Deploy\Quotation\*.* /F /Q		

xcopy ..\*.dll ..\..\Deploy\Quotation\ /Y /I
xcopy ..\ConsoleHost.exe ..\..\Deploy\Quotation
xcopy ConsoleHost.Quotation.config ..\..\Deploy\Quotation
rename ..\..\Deploy\Quotation\ConsoleHost.quotation.config ConsoleHost.exe.config

del ..\..\Deploy\Quotation\Portfolio.* /F /Q
del ..\..\Deploy\Quotation\Sales.* /F /Q