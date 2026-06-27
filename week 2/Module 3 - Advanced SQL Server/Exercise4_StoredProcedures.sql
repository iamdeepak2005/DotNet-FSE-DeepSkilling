-- stored procedures logic
-- deepa nair

IF OBJECT_ID('EmpProcDetails', 'U') IS NOT NULL DROP TABLE EmpProcDetails;

CREATE TABLE EmpProcDetails (
    EmpID INT PRIMARY KEY,
    Name VARCHAR(100),
    DepartmentID INT,
    Salary DECIMAL(10, 2)
);

INSERT INTO EmpProcDetails VALUES
(1, 'Amit Sharma', 10, 95000.00),
(2, 'Deepa Nair', 10, 110000.00);

-- proc 1: fetch employees
GO
CREATE OR ALTER PROCEDURE sp_GetEmployeesByDept
    @DeptID INT
AS
BEGIN
    SELECT EmpID, Name, Salary
    FROM EmpProcDetails
    WHERE DepartmentID = @DeptID;
END;
GO

-- proc 2: insert record
CREATE OR ALTER PROCEDURE sp_AddEmployee
    @EmpID INT,
    @Name VARCHAR(100),
    @DeptID INT,
    @Salary DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO EmpProcDetails VALUES (@EmpID, @Name, @DeptID, @Salary);
END;
GO

-- execution triggers
EXEC sp_GetEmployeesByDept 10;
EXEC sp_AddEmployee 3, 'John Doe', 20, 85000;
GO