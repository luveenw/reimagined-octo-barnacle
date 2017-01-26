-- !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
-- !!! DO NOT RUN UNLESS YOU REALLY WANT TO SEE IT IN ACTION !!!
-- !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
--
-- Compendium of responses listed in SQL.txt, except in a .sql file instead.

--
-- Requirement 7 / Requirement 9
--

DECLARE @custName varchar(40);
DECLARE @custId int;

SET @custName = 'George';
SET @custId = (
	SELECT CustomerID
	FROM Customer
	WHERE Name LIKE @custName
);

-- First answer: Names of salespeople who have an order with George
SELECT DISTINCT S.Name
FROM Salesperson S JOIN Orders O ON S.SalespersonID = O.SalespersonID
WHERE O.CustomerID = @custId;
GO

-- Second answer: Names of salespeople who do not have any order with George
SELECT DISTINCT S.Name
FROM Salesperson S
WHERE S.SalespersonID NOT IN (
	SELECT O.SalespersonID
	FROM Orders O JOIN Salesperson S ON O.SalespersonID = S.SalespersonID
	WHERE O.CustomerID = @custId
);
GO

-- Third answer: Names of salespeople with 2 or more orders
SELECT T2.Name FROM (
	SELECT S.Name, count(S.Name) AS NumSales
	FROM Salesperson S JOIN Orders O ON S.SalespersonID = O.SalespersonID
	GROUP BY S.Name
	HAVING count(S.Name) >= 2
) T2;
GO

--
-- Requirement 8 / Requirement 10
--

-- First answer: Name of the salesperson with the third highest salary
SELECT T2.Name FROM (
	SELECT S.Name, dense_rank() OVER (ORDER BY S.Salary DESC) AS Rank
	FROM Salesperson S
) T2
WHERE Rank = 3;
GO

-- Second answer:
-- Create roll-up table
CREATE TABLE BigOrders (
	CustomerID int NOT NULL PRIMARY KEY,
	TotalOrderValue money NOT NULL
);

-- Stored procedure to be run for initial table population. Also used in the trigger created below
CREATE PROCEDURE uspInsertBigOrders
AS
	WITH cte_TotalOrderValue AS (
		SELECT CustomerID, SUM(NumberOfUnits * CostOfUnit) AS TotalOrderValue
		FROM Orders
		GROUP BY CustomerID
	)
	INSERT INTO BigOrders
		SELECT CustomerID, TotalOrderValue
		FROM cte_TotalOrderValue
		WHERE TotalOrderValue > 1000;

-- Naive implementation of trigger to recalculate all total order values on insert, update, or delete.
-- A more efficient implementation would only update affected rows by examining the contents of the inserted and deleted tables.
CREATE TRIGGER trgAfterUpdateInsertOrDelete ON Orders
AFTER INSERT, UPDATE, DELETE
AS
	EXEC uspInsertBigOrders;
GO

-- Insert customers whose total Amount across all orders is greater than 1000
EXEC uspInsertBigOrders;
GO

-- Third Answer: Total Amount of orders for each month, ordered by year then month in descending order
SELECT OrderYear, OrderMonth, SUM(OrderValue) AS TotalOrderValue
FROM (
	SELECT YEAR(OrderDate) AS OrderYear, MONTH(OrderDate) AS OrderMonth, OrderID, NumberOfUnits * CostOfUnit AS OrderValue
	FROM Orders
) T2
GROUP BY OrderYear, OrderMonth
ORDER BY OrderYear, OrderMonth DESC;
GO
