-- week 2 training - advanced sql server concepts
-- author: deepa nair

-- setup tables
IF OBJECT_ID('OrderDetails', 'U') IS NOT NULL DROP TABLE OrderDetails;
IF OBJECT_ID('Orders', 'U') IS NOT NULL DROP TABLE Orders;
IF OBJECT_ID('Products', 'U') IS NOT NULL DROP TABLE Products;
IF OBJECT_ID('Customers', 'U') IS NOT NULL DROP TABLE Customers;

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name VARCHAR(100),
    Region VARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- mock details
INSERT INTO Customers VALUES 
(1, 'Alice Smith', 'North'), (2, 'Bob Jones', 'South'), (3, 'Charlie Davis', 'North');

INSERT INTO Products VALUES 
(101, 'Laptop', 'Electronics', 1200.00),
(102, 'Smartphone', 'Electronics', 800.00),
(103, 'Desk Chair', 'Office', 150.00),
(104, 'Paper shredder', 'Office', 85.00);

INSERT INTO Orders VALUES 
(1, 1, '2026-06-01'), (2, 2, '2026-06-05'), (3, 3, '2026-06-10');

INSERT INTO OrderDetails VALUES 
(10, 1, 101, 1), (11, 1, 103, 2),
(12, 2, 102, 1), (13, 3, 104, 1);

-- query 1: window functions
SELECT 
    ProductName,
    Category,
    Price,
    ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum,
    RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS PriceRank
FROM Products;

-- query 2: group aggregations (CUBE)
SELECT 
    c.Region,
    p.Category,
    SUM(od.Quantity * p.Price) AS TotalSales
FROM OrderDetails od
INNER JOIN Orders o ON od.OrderID = o.OrderID
INNER JOIN Customers c ON o.CustomerID = c.CustomerID
INNER JOIN Products p ON od.ProductID = p.ProductID
GROUP BY CUBE(c.Region, p.Category);

-- query 3: CTE spending
WITH SpendSummary AS (
    SELECT 
        o.CustomerID,
        SUM(od.Quantity * p.Price) AS TotalSpent
    FROM Orders o
    INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
    INNER JOIN Products p ON od.ProductID = p.ProductID
    GROUP BY o.CustomerID
)
SELECT * FROM SpendSummary WHERE TotalSpent > 500;