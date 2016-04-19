SELECT * FROM [Sales].[Customer] C
	INNER JOIN [Person].[Person] P ON C.PersonId = P.[BusinessEntityID]
--WHERE C.CustomerID=11019

SELECT CustomerID, count(*) as Orders
  FROM [Sales].[SalesOrderHeader]
GROUP BY CustomerID

SELECT *
				FROM [Sales].[SalesOrderHeader] SO 
					INNER JOIN [Sales].[Customer] C ON SO.CustomerID=C.CustomerId
					INNER JOIN [Person].[Person] P ON P.BusinessEntityID=C.PersonId
			WHERE P.LastName='Abel'