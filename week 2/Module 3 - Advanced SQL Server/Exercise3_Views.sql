-- database views setup
-- author: deepa nair

IF OBJECT_ID('EmpViewDetails', 'U') IS NOT NULL DROP TABLE EmpViewDetails;

CREATE TABLE EmpViewDetails (
    EmpID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    MonthlySalary DECIMAL(10, 2),
    Department VARCHAR(50)
);

INSERT INTO EmpViewDetails VALUES
(1, 'Amit', 'Sharma', 8000.00, 'IT'),
(2, 'Deepa', 'Nair', 9500.00, 'IT');

-- view 1: simple view
GO
CREATE OR ALTER VIEW v_SimpleEmployees AS
SELECT EmpID, FirstName, Department
FROM EmpViewDetails;
GO

-- view 2: view with calculated annual salary
CREATE OR ALTER VIEW v_EmployeeSalaries AS
SELECT 
    EmpID,
    CONCAT(FirstName, ' ', LastName) AS FullName,
    Department,
    (MonthlySalary * 12) AS AnnualSalary
FROM EmpViewDetails;
GO

-- query views
SELECT * FROM v_SimpleEmployees;
SELECT * FROM v_EmployeeSalaries;
GO