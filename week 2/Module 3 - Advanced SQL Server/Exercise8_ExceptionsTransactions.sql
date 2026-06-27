-- try catch exception and database transaction management
-- deepa nair

IF OBJECT_ID('EmpAccounts', 'U') IS NOT NULL DROP TABLE EmpAccounts;

CREATE TABLE EmpAccounts (
    AccountID INT PRIMARY KEY,
    HolderName VARCHAR(100),
    Balance DECIMAL(10, 2) CHECK (Balance >= 0)
);

INSERT INTO EmpAccounts VALUES
(1, 'Amit Sharma', 1000.00),
(2, 'Deepa Nair', 1500.00);

GO
CREATE OR ALTER PROCEDURE sp_TransferFunds
    @Sender INT,
    @Receiver INT,
    @Amount DECIMAL(10, 2)
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        -- deduct amount from sender
        UPDATE EmpAccounts
        SET Balance = Balance - @Amount
        WHERE AccountID = @Sender;

        -- add amount to receiver
        UPDATE EmpAccounts
        SET Balance = Balance + @Amount
        WHERE AccountID = @Receiver;

        COMMIT TRANSACTION;
        PRINT 'Funds transfer completed successfully.';
    END TRY
    BEGIN CATCH
        -- rollback if transaction failed
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END
        PRINT 'Transfer failed and transaction rolled back. Error: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;
GO

-- execute
EXEC sp_TransferFunds 1, 2, 100.00;
SELECT * FROM EmpAccounts;
GO