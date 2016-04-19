SELECT *
 FROM [Sales].[SalesOrderHeader] SO 
	INNER JOIN [Person].[Person] P ON P.BusinessEntityID=SO.SalesPersonId
