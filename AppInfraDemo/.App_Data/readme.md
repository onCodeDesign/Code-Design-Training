Use this folder when you want to use the AdventureWorks2012 database from the local SQL Express.
-----------------

The `AppInfraDemo\.App_Data` folder should contain the `AdventureWorks2012.mdf` in order to be attached to the local database on the application start. 

To configure this follow these steps:
 1. Download the `AdventureWorks2012.mdf` from [https://msftdbprodsamples.codeplex.com/downloads/get/165399](https://msftdbprodsamples.codeplex.com/downloads/get/165399) or from [https://1drv.ms/u/s!AttpJoJRCtSQiiG8WJT8t3C4y450](http://example.com)
 2. Copy it to `AppInfraDemo\.App_Data` folder 
 3. Make sure that your host app sets the |DataDirectory| on the AppDomain
    - see `AppInfraDemo\UI\ConsoleApplication\Program.SetupDataDirectory()`
 4. Set the connection string that uses `AttachDbFilename` setting
    - see `AppInfraDemo\UI\ConsoleApplication\App.config`
    - ex: `data source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AdventureWorks2012.mdf;initial catalog=AdventureWorks2012;Integrated Security=True;MultipleActiveResultSets=True;App=EntityFramework`
    - make sure that the `AdventureWorks2012.mdf` file name matches the one in the connection string