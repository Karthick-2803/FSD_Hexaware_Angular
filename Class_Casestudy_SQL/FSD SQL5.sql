use TranscationDb

CREATE TABLE Orders ( 
    OrderID INT IDENTITY(1,1) PRIMARY KEY, 
    CustomerName VARCHAR(100), 
    OrderDate DATETIME DEFAULT GETDATE() 
)

CREATE TABLE OrderItems ( 
    OrderItemID INT IDENTITY(1,1) PRIMARY KEY, 
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID), 
    ProductName VARCHAR(100), 
    Quantity INT, 
    UnitPrice DECIMAL(10,2) 
)


BEGIN TRY
    BEGIN TRANSACTION

    INSERT INTO Orders (CustomerName)
    VALUES ('John Doe')

    DECLARE @NewOrderID INT = SCOPE_IDENTITY();

    
    INSERT INTO OrderItems (OrderID, ProductName, Quantity, UnitPrice)
    VALUES 
        (@NewOrderID, 'Mouse', 2, 500.00),
        (@NewOrderID, 'Keyboard', 1, 1200.00),
        (@NewOrderID, 'Monitor', 1, 8500.00)

   
    COMMIT TRANSACTION;
    PRINT 'Transaction committed successfully.';
END TRY
BEGIN CATCH
   
    ROLLBACK TRANSACTION;

    PRINT 'Transaction rolled back due to error.';
    PRINT ERROR_MESSAGE();
END CATCH

-- Check Orders
SELECT * FROM Orders

-- Check OrderItems
SELECT * FROM OrderItems