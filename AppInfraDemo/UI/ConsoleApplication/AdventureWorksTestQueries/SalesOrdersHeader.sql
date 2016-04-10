SELECT * FROM [Sales].[Customer] C
	INNER JOIN [Person].[Person] P ON C.PersonId = P.[BusinessEntityID]
--WHERE C.CustomerID=11019

SELECT CustomerID, count(*) as Orders
  FROM [Sales].[SalesOrderHeader]
GROUP BY CustomerID