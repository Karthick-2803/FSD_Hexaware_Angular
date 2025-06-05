use Triggers

--Main table
create table Employees (
    EmpID int primary key,
    EmpName varchar(100),
    Department varchar(50),
    Salary decimal(10, 2)
)

--creating audit table
create table EmployeeAuditLog (
    LogID int identity(1,1) primary key,
    EmpID int,
    EmpName varchar(100),
    Department varchar(50),
    Salary decimal(10,2),
    ActionType varchar(10),           
    ActionDate datetime default getdate()
)

CREATE TRIGGER trg_EmployeeInsert
ON Employees
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO EmployeeAuditLog(
	EmpID,EmpName,Department,Salary,ActionType)
	SELECT i.EmpID,i.EmpName,i.Department,i.Salary,'INSERT' FROM INSERTED i 
END

--inserting triggers
insert into Employees (EmpID, EmpName, Department, Salary)
VALUES 
(1, 'Krishna', 'HR', 55000)
insert into Employees (EmpID, EmpName, Department, Salary)
VALUES(2, 'Jeffin', 'IT', 70000)

CREATE TRIGGER trg_EmployeeDelete
ON Employees
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO EmployeeAuditLog(
	EmpID,EmpName,Department,Salary,ActionType)
	SELECT i.EmpID,i.EmpName,i.Department,i.Salary,'DELETE' FROM DELETED i 
END


SELECT * FROM EmployeeAuditLog

DELETE FROM Employees WHERE EmpID = 1



