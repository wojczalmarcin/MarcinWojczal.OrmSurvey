namespace MarcinWojczal.OrmSurvey.Dapper
{
    internal static class Queries
    {
        internal const string SelectOrderById = "SELECT " +
            "o.OrderID AS Id, " +
            "o.CustomerID," +
            "o.EmployeeID," +
            "o.OrderDate," +
            "o.RequiredDate," +
            "o.ShippedDate," +
            "o.ShipVia AS ShipperID," +
            "o.Freight," +
            "o.ShipName," +
            "o.ShipAddress," +
            "o.ShipRegion," +
            "o.ShipPostalCode," +
            "o.ShipCountry " +
            "FROM Orders AS o WITH (NOLOCK)" +
            "WHERE o.OrderID = @orderId;";

        internal const string SelectTopOrders = "SELECT TOP (@numberOfOrders) " +
            "o.OrderID AS Id, " +
            "o.CustomerID," +
            "o.EmployeeID," +
            "o.OrderDate," +
            "o.RequiredDate," +
            "o.ShippedDate," +
            "o.ShipVia AS ShipperID," +
            "o.Freight," +
            "o.ShipName," +
            "o.ShipAddress," +
            "o.ShipRegion," +
            "o.ShipPostalCode," +
            "o.ShipCountry " +
            "FROM Orders AS o WITH (NOLOCK) " +
            "WHERE o.OrderDate > @orderDate;";

        internal const string SelectOrderWithDetailsAndEmployeeById = "SELECT " +
            "o.OrderID AS Id," +
            "o.CustomerID," +
            "o.EmployeeID," +
            "o.OrderDate," +
            "o.RequiredDate," +
            "o.ShippedDate," +
            "o.ShipVia AS ShipperID," +
            "o.Freight," +
            "o.ShipName," +
            "o.ShipAddress," +
            "o.ShipRegion," +
            "o.ShipPostalCode," +
            "o.ShipCountry," +
            "od.OrderID AS Id," +
            "od.OrderID," +
            "od.ProductID," +
            "od.UnitPrice," +
            "od.Quantity," +
            "od.Discount," +
            "e.EmployeeID AS Id," +
            "e.LastName," +
            "e.FirstName," +
            "e.Title," +
            "e.TitleOfCourtesy," +
            "e.BirthDate," +
            "e.HireDate," +
            "e.Address," +
            "e.City," +
            "e.Region," +
            "e.PostalCode," +
            "e.Country," +
            "e.HomePhone," +
            "e.Extension," +
            "e.Photo," +
            "e.Notes," +
            "e.ReportsTo," +
            "e.PhotoPath," +
            "r.EmployeeID AS Id," +
            "r.LastName," +
            "r.FirstName," +
            "r.Title," +
            "r.TitleOfCourtesy," +
            "r.BirthDate," +
            "r.HireDate," +
            "r.Address," +
            "r.City," +
            "r.Region," +
            "r.PostalCode," +
            "r.Country," +
            "r.HomePhone," +
            "r.Extension," +
            "r.Photo," +
            "r.Notes," +
            "r.ReportsTo," +
            "r.PhotoPath," +
            "t.TerritoryID AS Id," +
            "t.TerritoryDescription," +
            "t.RegionID " +
            "FROM Orders AS o WITH (NOLOCK) " +
            "LEFT JOIN [Order Details] AS od WITH (NOLOCK) " +
            "ON o.OrderID = od.OrderID " +
            "LEFT JOIN Employees AS e WITH (NOLOCK) " +
            "ON o.EmployeeID = e.EmployeeID " +
            "LEFT JOIN Employees AS r WITH (NOLOCK) " +
            "ON e.ReportsTo = r.EmployeeID " +
            "LEFT JOIN EmployeeTerritories AS et WITH (NOLOCK) " +
            "ON r.EmployeeID = et.EmployeeID " +
            "LEFT JOIN Territories AS t " +
            "ON et.TerritoryID = t.TerritoryID " +
            "WHERE o.OrderID = @orderId;";

        internal const string InsertOrders = "INSERT INTO Orders (" +
            "CustomerID, " +
            "EmployeeID, " +
            "OrderDate, " +
            "RequiredDate, " +
            "ShippedDate, " +
            "ShipVia, " +
            "Freight, " +
            "ShipName, " +
            "ShipAddress, " +
            "ShipCity, " +
            "ShipRegion, " +
            "ShipPostalCode, " +
            "ShipCountry " +
            ") OUTPUT INSERTED.OrderID " +
            "VALUES " +
            "(@CustomerID, " +
            "@EmployeeID, " +
            "@OrderDate, " +
            "@RequiredDate, " +
            "@ShippedDate, " +
            "@ShipperID, " +
            "@Freight, " +
            "@ShipName, " +
            "@ShipAddress, " +
            "@ShipCity, " +
            "@ShipRegion, " +
            "@ShipPostalCode, " +
            "@ShipCountry" +
            ");";

        internal const string InsertOrderDetails = "INSERT INTO [Order Details] (" +
            "OrderID, " +
            "ProductID, " +
            "UnitPrice, " +
            "Quantity, " +
            "Discount " +
            ") VALUES " +
            "(@orderID, " +
            "@productID, " +
            "@unitPrice, " +
            "@quantity, " +
            "@discount " +
            "); ";

        internal const string SelectTopOrdersWithDetailsAndEmployee = "SELECT " +
            "o.OrderID AS Id," +
            "o.CustomerID," +
            "o.EmployeeID," +
            "o.OrderDate," +
            "o.RequiredDate," +
            "o.ShippedDate," +
            "o.ShipVia AS ShipperID," +
            "o.Freight," +
            "o.ShipName," +
            "o.ShipAddress," +
            "o.ShipRegion," +
            "o.ShipPostalCode," +
            "o.ShipCountry," +
            "od.OrderID AS Id," +
            "od.OrderID," +
            "od.ProductID," +
            "od.UnitPrice," +
            "od.Quantity," +
            "od.Discount," +
            "e.EmployeeID AS Id," +
            "e.LastName," +
            "e.FirstName," +
            "e.Title," +
            "e.TitleOfCourtesy," +
            "e.BirthDate," +
            "e.HireDate," +
            "e.Address," +
            "e.City," +
            "e.Region," +
            "e.PostalCode," +
            "e.Country," +
            "e.HomePhone," +
            "e.Extension," +
            "e.Photo," +
            "e.Notes," +
            "e.ReportsTo," +
            "e.PhotoPath," +
            "r.EmployeeID AS Id," +
            "r.LastName," +
            "r.FirstName," +
            "r.Title," +
            "r.TitleOfCourtesy," +
            "r.BirthDate," +
            "r.HireDate," +
            "r.Address," +
            "r.City," +
            "r.Region," +
            "r.PostalCode," +
            "r.Country," +
            "r.HomePhone," +
            "r.Extension," +
            "r.Photo," +
            "r.Notes," +
            "r.ReportsTo," +
            "r.PhotoPath," +
            "t.TerritoryID AS Id," +
            "t.TerritoryDescription," +
            "t.RegionID " +
            "FROM (SELECT TOP(@numberOfOrders) * " +
            "   FROM Orders WITH (NOLOCK)" +
            "   ORDER BY OrderID DESC) AS o " +
            "LEFT JOIN [Order Details] AS od WITH (NOLOCK) " +
            "ON o.OrderID = od.OrderID " +
            "LEFT JOIN Employees AS e WITH (NOLOCK) " +
            "ON o.EmployeeID = e.EmployeeID " +
            "LEFT JOIN Employees AS r WITH (NOLOCK) " +
            "ON e.ReportsTo = r.EmployeeID " +
            "LEFT JOIN EmployeeTerritories AS et WITH (NOLOCK) " +
            "ON r.EmployeeID = et.EmployeeID " +
            "LEFT JOIN Territories AS t " +
            "ON et.TerritoryID = t.TerritoryID;";

        internal const string SelectTopOrdersWithDetailsAndEmployeeWhereOrderDate = "SELECT " +
            "o.OrderID AS Id," +
            "o.CustomerID," +
            "o.EmployeeID," +
            "o.OrderDate," +
            "o.RequiredDate," +
            "o.ShippedDate," +
            "o.ShipVia AS ShipperID," +
            "o.Freight," +
            "o.ShipName," +
            "o.ShipAddress," +
            "o.ShipRegion," +
            "o.ShipPostalCode," +
            "o.ShipCountry," +
            "od.OrderID AS Id," +
            "od.OrderID," +
            "od.ProductID," +
            "od.UnitPrice," +
            "od.Quantity," +
            "od.Discount," +
            "e.EmployeeID AS Id," +
            "e.LastName," +
            "e.FirstName," +
            "e.Title," +
            "e.TitleOfCourtesy," +
            "e.BirthDate," +
            "e.HireDate," +
            "e.Address," +
            "e.City," +
            "e.Region," +
            "e.PostalCode," +
            "e.Country," +
            "e.HomePhone," +
            "e.Extension," +
            "e.Photo," +
            "e.Notes," +
            "e.ReportsTo," +
            "e.PhotoPath," +
            "r.EmployeeID AS Id," +
            "r.LastName," +
            "r.FirstName," +
            "r.Title," +
            "r.TitleOfCourtesy," +
            "r.BirthDate," +
            "r.HireDate," +
            "r.Address," +
            "r.City," +
            "r.Region," +
            "r.PostalCode," +
            "r.Country," +
            "r.HomePhone," +
            "r.Extension," +
            "r.Photo," +
            "r.Notes," +
            "r.ReportsTo," +
            "r.PhotoPath," +
            "t.TerritoryID AS Id," +
            "t.TerritoryDescription," +
            "t.RegionID " +
            "FROM (SELECT TOP(@numberOfOrders) * " +
            "   FROM Orders WITH (NOLOCK) " +
            "   WHERE OrderDate > @orderDate) AS o " +
            "LEFT JOIN [Order Details] AS od WITH (NOLOCK) " +
            "ON o.OrderID = od.OrderID " +
            "LEFT JOIN Employees AS e WITH (NOLOCK) " +
            "ON o.EmployeeID = e.EmployeeID " +
            "LEFT JOIN Employees AS r WITH (NOLOCK) " +
            "ON e.ReportsTo = r.EmployeeID " +
            "LEFT JOIN EmployeeTerritories AS et WITH (NOLOCK) " +
            "ON r.EmployeeID = et.EmployeeID " +
            "LEFT JOIN Territories AS t " +
            "ON et.TerritoryID = t.TerritoryID;";

        internal const string UpdateOrderDetails = "UPDATE dbo.[Order Details] " +
            "SET UnitPrice = @unitPrice " +
            "WHERE OrderID = @orderID " +
        "AND ProductID = @productID;";

        internal const string UpdateOrder = "UPDATE dbo.Orders " +
            "SET ShipRegion = @shipRegion " +
            "WHERE OrderID = @orderID";

        internal const string DeleteOrderWithDetails = "DELETE FROM dbo.[Order Details] " +
            "WHERE OrderID = @orderId;" +
            "DELETE FROM dbo.Orders " +
            "WHERE OrderID = @orderId;";

        internal const string DeleteOrdersWithDetails = "DELETE FROM dbo.[Order Details] " +
            "WHERE OrderID IN @ordersIds ;" +
            "DELETE FROM dbo.Orders " +
            "WHERE OrderID IN @ordersIds ;";
    }
}
