-- databases trigger actions
-- deepa nair

IF OBJECT_ID('EmployeeChanges', 'U') IS NOT NULL DROP TABLE EmployeeChanges;
IF OBJECT_ID('EmpTriggerDetails', 'U') IS NOT NULL DROP TABLE EmpTriggerDetails;

CREATE TABLE EmpTriggerDetails (
    EmpID INT PRIMARY KEY,
    Name VARCHAR(100),
    Salary DECIMAL(10, 2)
);

CREATE TABLE EmployeeChanges (
    LogID INT IDENTITY PRIMARY KEY,
    EmpID INT,
    ChangeMsg VARCHAR(255),
    ChangeTime DATETIME DEFAULT GETDATE()
);

INSERT INTO EmpTriggerDetails VALUES
(1, 'Amit Sharma', 95000.00),
(2, 'Deepa Nair', 110000.00);

-- after update trigger log
GO
CREATE OR ALTER TRIGGER trg_AuditEmployeeSalary
ON EmpTriggerDetails
AFTER UPDATE
AS
BEGIN
    INSERT INTO EmployeeChanges (EmpID, ChangeMsg)
    SELECT EmpID, 'Salary update action captured.'
    FROM inserted;
END;
GO

-- instead of delete trigger restriction
CREATE OR ALTER TRIGGER trg_BlockDeletes
ON EmpTriggerDetails
INSTEAD OF DELETE
AS
BEGIN
    RAISERROR ('Deletion is not permitted on this table.', 16, 1);
END;
GO