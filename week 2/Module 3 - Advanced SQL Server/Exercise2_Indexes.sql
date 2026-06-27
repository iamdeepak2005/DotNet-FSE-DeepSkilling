-- indexing configuration exercises
-- deepa nair

IF OBJECT_ID('Employees', 'U') IS NOT NULL DROP TABLE Employees;

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY, -- primary key automatically clustered index
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT,
    Salary DECIMAL(10, 2),
    Email VARCHAR(100)
);

INSERT INTO Employees VALUES
(1, 'Amit', 'Sharma', 10, 95000.00, 'amit@test.com'),
(2, 'Deepa', 'Nair', 10, 110000.00, 'deepa@test.com'),
(3, 'Charlie', 'Davis', 20, 85000.00, 'charlie@test.com');

-- non clustered index for quick string lookup queries
CREATE NONCLUSTERED INDEX IX_Employees_LastName 
ON Employees (LastName);

-- covering index for department salary queries
CREATE NONCLUSTERED INDEX IX_Employees_DeptSalary
ON Employees (DepartmentID)
INCLUDE (FirstName, LastName, Salary);

-- query covered by index
SELECT FirstName, LastName, Salary 
FROM Employees 
WHERE DepartmentID = 10;