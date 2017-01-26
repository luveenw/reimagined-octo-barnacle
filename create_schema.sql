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
	SalespersonID int NOT NULL PRIMARY KEY,
	Name varchar(40) NOT NULL,
	Age int NOT NULL,
	Salary money NOT NULL
);

CREATE TABLE Customer(
	CustomerID int NOT NULL PRIMARY KEY,
	Name varchar(40) NOT NULL
);

CREATE TABLE Orders(
	OrderID int NOT NULL PRIMARY KEY,
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

-- Create table indexes to support faster lookups on non-primary-key columns
CREATE INDEX idx_Salesperson_Name ON Salesperson (Name);

CREATE INDEX idx_Customer_Name ON Customer (Name);
GO
