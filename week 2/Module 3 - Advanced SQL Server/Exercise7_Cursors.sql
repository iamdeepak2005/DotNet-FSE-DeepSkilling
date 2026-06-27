-- database cursors looping script
-- author: deepa nair

IF OBJECT_ID('EmpCursorDetails', 'U') IS NOT NULL DROP TABLE EmpCursorDetails;

CREATE TABLE EmpCursorDetails (
    EmpID INT PRIMARY KEY,
    Name VARCHAR(100),
    Salary DECIMAL(10, 2)
);

INSERT INTO EmpCursorDetails VALUES
(1, 'Amit Sharma', 95000.00),
(2, 'Deepa Nair', 110000.00);

GO
DECLARE @Id INT;
DECLARE @Name VARCHAR(100);
DECLARE @Sal DECIMAL(10,2);

DECLARE emp_cursor CURSOR FOR
SELECT EmpID, Name, Salary FROM EmpCursorDetails;

OPEN emp_cursor;
FETCH NEXT FROM emp_cursor INTO @Id, @Name, @Sal;

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'Loaded employee: ' + @Name + ' | Salary: $' + CAST(@Sal AS VARCHAR(10));
    FETCH NEXT FROM emp_cursor INTO @Id, @Name, @Sal;
END;

CLOSE emp_cursor;
DEALLOCATE emp_cursor;
GO