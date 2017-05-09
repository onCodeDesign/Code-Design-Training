cd %1

del ..\..\Deploy\ConsoleUi\*.* /F /Q		

xcopy ..\*.dll ..\..\Deploy\ConsoleUi\ /Y /I
xcopy ..\ConsoleUi.exe* ..\..\Deploy\ConsoleUi


del ..\..\Deploy\ConsoleUi\Quotations.* /F /Q
del ..\..\Deploy\ConsoleUi\Portfolio.* /F /Q
del ..\..\Deploy\ConsoleUi\Sales.* /F /Q