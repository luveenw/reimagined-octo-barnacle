-- Prerequisites to run these queries:
-- 1. Install SQL Local DB (https://download.microsoft.com/download/8/D/D/8DD7BDBA-CEF7-4D8E-8C16-D9F69527F909/ENU/x64/SqlLocalDB.MSI)
-- 2. Install SQL Command Line Utilities (http://go.microsoft.com/fwlink/?LinkID=239649&clcid=0x409)
-- 3. Create a database instance in a command-line terminal by invoking the following commands:
-- 		SqlLocalDb create -s "MyInstance"
-- 		cd "c:\Program Files\Microsoft SQL Server\110\Tools\Binn"
-- 		sqlcmd -S (localdb)\MyInstance

-- Create database. Drop any pre-existing database with the same name.
USE master;
GO

IF EXISTS (
	SELECT *
	FROM sys.databases
	WHERE name='CMCS_Sales'
)

BEGIN
	DROP DATABASE CMCS_Sales;
END

CREATE DATABASE CMCS_Sales;
GO

-- Define database schema
USE CMCS_Sales;
GO

CREATE TABLE Salesperson(
	SalespersonID int PRIMARY KEY NOT NULL,
	Name varchar(40) NOT NULL,
	Age int NOT NULL,
	Salary money NOT NULL
);

CREATE TABLE Customer(
	CustomerID int PRIMARY KEY NOT NULL,
	Name varchar(40) NOT NULL
);

CREATE TABLE Orders(
	OrderID int PRIMARY KEY NOT NULL,
	OrderDate date NOT NULL,
	CustomerID int NOT NULL,
	SalespersonID int NOT NULL,
	NumberOfUnits int NOT NULL,
	CostOfUnit money NOT NULL,
	CONSTRAINT FK_Customer_Order FOREIGN KEY (CustomerID)
	REFERENCES Customer(CustomerID)
	ON DELETE CASCADE,
	CONSTRAINT FK_Salesperson_Order FOREIGN KEY (SalespersonID)
	REFERENCES Salesperson(SalespersonID)
	ON DELETE CASCADE
);
GO

-- List tables in database to visually verify that all required tables were created successfully
SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG='CMCS_Sales';
GO

-- Create table indexes to support faster lookups on non-primary-key columns
CREATE INDEX IDX_Salesperson_Name ON Salesperson (Name);

CREATE INDEX IDX_Customer_Name ON Customer (Name);

-- Insert table data
INSERT INTO Salesperson (SalespersonID, Name, Age, Salary) VALUES
	(1, 'Alice', 61, 140000),
	(2, 'Bob', 34, 44000),
	(6, 'Chris', 34, 40000),
	(8, 'Derek', 41, 52000),
	(11, 'Emmit', 57, 115000),
	(16, 'Fred', 38, 38000);

INSERT INTO Customer (CustomerID, Name) VALUES
	(4, 'George'),
	(6, 'Harry'),
	(7, 'Ingrid'),
	(11, 'Jerry');

INSERT INTO Orders (OrderID, OrderDate, CustomerID, SalespersonID, NumberOfUnits, CostOfUnit) VALUES
	(3, '2013-01-17', 4, 2, 4, 400),
	(6, '2013-02-07', 4, 1, 1, 600),
	(10, '2013-03-04', 7, 6, 2, 300),
	(17, '2013-03-15', 6, 1, 5, 300),
	(25, '2013-04-19', 11, 11, 7, 300),
	(34, '2013-04-22', 11, 11, 100, 26),
	(57, '2013-07-12', 7, 11, 14, 11);
GO

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

-- Names of salespeople who have an order with George
SELECT DISTINCT S.Name
FROM Salesperson S JOIN Orders O ON S.SalespersonID = O.SalespersonID
WHERE O.CustomerID = @custId;

-- Names of salespeople who do not have an order with George
SELECT DISTINCT S.Name
FROM Salesperson S JOIN Orders O ON S.SalespersonID = O.SalespersonID
WHERE O.CustomerID != @custId;
GO

-- Names of salespeople with 2 or more orders
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

-- Name of the salesperson with the third highest salary
SELECT T2.Name FROM (
	SELECT S.Name, dense_rank() over (ORDER BY S.Salary DESC) AS rank
	FROM Salesperson S
) T2
WHERE rank = 3;
GO
