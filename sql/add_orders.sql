USE [Northwind];
GO

BEGIN TRAN AAA;

DECLARE @i INT = 0;
DECLARE @orderID INT;
--DECLARE orderCursor CURSOR FOR 
--		SELECT TOP 800 OrderID
--		FROM dbo.Orders
--		ORDER BY OrderID DESC;

--SELECT TOP 1000 [OrderID]
--			,[ProductID]
--			,[UnitPrice]
--			,[Quantity]
--			,[Discount]
--		INTO #orderDetails
--		FROM dbo.[Order Details]

WHILE @i < 1000
BEGIN
	INSERT INTO [dbo].[Orders]
           ([CustomerID]
           ,[EmployeeID]
           ,[OrderDate]
           ,[RequiredDate]
           ,[ShippedDate]
           ,[ShipVia]
           ,[Freight]
           ,[ShipName]
           ,[ShipAddress]
           ,[ShipCity]
           ,[ShipRegion]
           ,[ShipPostalCode]
           ,[ShipCountry])
	SELECT TOP 800 [CustomerID]
		,[EmployeeID]
		,[OrderDate]
		,[RequiredDate]
		,[ShippedDate]
		,[ShipVia]
		,[Freight]
		,[ShipName]
		,[ShipAddress]
		,[ShipCity]
		,[ShipRegion]
		,[ShipPostalCode]
		,[ShipCountry]
	FROM dbo.Orders
	ORDER BY OrderID DESC;

	INSERT INTO [dbo].[Order Details]
			([OrderID]
			,[ProductID]
			,[UnitPrice]
			,[Quantity]
			,[Discount])
		SELECT TOP 800 OrderId
			,CAST(ABS(CHECKSUM(NewId())) % 70 + 1 AS INT)
			,CAST(ABS(CHECKSUM(NewId())) % 100000 * 0.01 + 1 AS MONEY)
			,CAST(ABS(CHECKSUM(NewId())) % 100 + 1 AS INT)
			,CAST(ABS(CHECKSUM(NewId())) % 100 * 0.01 AS REAL)
		FROM dbo.Orders
		ORDER BY dbo.Orders.OrderID DESC;

	--OPEN orderCursor;
	--FETCH NEXT FROM orderCursor INTO @orderID;
	--
	--WHILE @@FETCH_STATUS = 0
	--BEGIN
	--	DROP TABLE IF EXISTS #orderDetail;
	--	SELECT TOP 1 @OrderID AS OrderId
	--		,[ProductID]
	--		,[UnitPrice]
	--		,[Quantity]
	--		,[Discount]
	--	INTO #orderDetail
	--	FROM #orderDetails
	--	ORDER BY NEWID();
	--
	--	INSERT INTO [dbo].[Order Details]
	--		([OrderID]
	--		,[ProductID]
	--		,[UnitPrice]
	--		,[Quantity]
	--		,[Discount])
	--	SELECT OrderId
	--		,[ProductID]
	--		,[UnitPrice]
	--		,[Quantity]
	--		,[Discount]
	--	FROM #orderDetail;

		--IF @i % 2 = 0
		--BEGIN
		--	INSERT INTO [dbo].[Order Details]
		--		([OrderID]
		--		,[ProductID]
		--		,[UnitPrice]
		--		,[Quantity]
		--		,[Discount])
		--	SELECT TOP 1 @OrderID
		--		,[ProductID]
		--		,[UnitPrice]
		--		,[Quantity]
		--		,[Discount]
		--	FROM #orderDetails
		--	WHERE NOT EXISTS( SELECT ProductID FROM #orderDetail WHERE ProductID = ProductID)
		--	ORDER BY NEWID();
		--END;

	--	FETCH NEXT FROM orderCursor INTO @orderID;
	--END;
	--CLOSE orderCursor;
	SET @i = @i + 1;
END;

--SELECT * FROM Orders AS o
--INNER JOIN [Order Details] AS od ON o.OrderID = od.OrderID ORDER BY o.OrderID DESC;
--ROLLBACK TRAN AAA;
SELECT COUNT(*) FROM Orders;
COMMIT TRAN AAA

