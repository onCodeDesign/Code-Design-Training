cd %1

call .\Deploy-HostPortfolio.bat
call .\Deploy-HostQuotation.bat
call .\Deploy-HostSales.bat

copy startAll.bat ..\..\Deploy