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
