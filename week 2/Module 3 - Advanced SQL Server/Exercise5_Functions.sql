-- user defined functions
-- author: deepa nair

IF OBJECT_ID('EmpFuncDetails', 'U') IS NOT NULL DROP TABLE EmpFuncDetails;

CREATE TABLE EmpFuncDetails (
    EmpID INT PRIMARY KEY,
    Name VARCHAR(100),
    MonthlySalary DECIMAL(10, 2),
    DepartmentID INT
);

INSERT INTO EmpFuncDetails VALUES
(1, 'Amit Sharma', 8000.00, 10),
(2, 'Deepa Nair', 9500.00, 10);

-- scalar function
GO
CREATE OR ALTER FUNCTION fn_GetAnnualSalary
(
    @MonthlySalary DECIMAL(10, 2)
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    RETURN @MonthlySalary * 12;
END;
GO

-- inline table-valued function
CREATE OR ALTER FUNCTION fn_GetDeptEmployees
(
    @DeptID INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT EmpID, Name, MonthlySalary
    FROM EmpFuncDetails
    WHERE DepartmentID = @DeptID
);
GO

-- testing queries
SELECT Name, dbo.fn_GetAnnualSalary(MonthlySalary) AS AnnualSalary FROM EmpFuncDetails;
SELECT * FROM dbo.fn_GetDeptEmployees(10);
GO