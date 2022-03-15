USE master;
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name = 'Shop')
BEGIN
	DROP DATABASE Shop
END;
GO

CREATE DATABASE Shop;
GO

USE Shop;
GO

IF EXISTS
( 
	SELECT TOP(1) 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_NAME = N'Orders' AND TABLE_SCHEMA = 'dbo' 
) 
DROP TABLE dbo.Orders;
GO

IF EXISTS
( 
	SELECT TOP(1) 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_NAME = N'Products' AND TABLE_SCHEMA = 'dbo' 
) 
DROP TABLE dbo.Products;
GO

IF EXISTS
( 
	SELECT TOP(1) 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_NAME = N'Categories' AND TABLE_SCHEMA = 'dbo' 
) 
DROP TABLE dbo.Categories;
GO

CREATE TABLE dbo.Categories
(
	CategoryID INT IDENTITY(1,1) NOT NULL,
	CategoryName VARCHAR(20) NOT NULL,
	PRIMARY KEY(CategoryID)
) 
GO

INSERT INTO dbo.Categories(CategoryName)
VALUES (N'Сhocolate'), (N'Drink'), (N'Juice'), (N'Fruit'), (N'Vegetable');
GO

CREATE TABLE dbo.Products
(
	ProductID INT IDENTITY(1,1) NOT NULL,
	ProductName VARCHAR(20) NOT NULL,
	PRIMARY KEY (ProductID)
);
GO 

INSERT INTO dbo.Products(ProductName)
VALUES (N'J7'), (N'Carrot'), (N'Ball');
GO

CREATE TABLE dbo.Orders
(
	OrderID INT IDENTITY(1,1) NOT NULL,
	PRIMARY KEY(OrderID),
	ProductID INT NOT NULL,
	CategoryID INT,
	CONSTRAINT FK_CategoryID FOREIGN KEY (CategoryID)
	REFERENCES dbo.Categories(CategoryID), 
	CONSTRAINT FK_ProductID FOREIGN KEY (ProductID)
	REFERENCES dbo.Products(ProductID) 
) 
GO

INSERT INTO dbo.Orders(ProductID,CategoryID)
VALUES  (1, 3), (1, 4), (2, 5), (3, Null);
GO

SELECT prod.ProductName, cat.CategoryName 
FROM dbo.Orders AS ord
JOIN dbo.Products AS prod ON prod.ProductID = ord.ProductID
LEFT JOIN dbo.Categories AS cat ON cat.CategoryID = ord.CategoryID
GROUP BY prod.ProductName, cat.CategoryName
GO

