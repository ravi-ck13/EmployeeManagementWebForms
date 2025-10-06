-- Table
CREATE TABLE Employees (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Department NVARCHAR(100),
    Email NVARCHAR(100)
);

-- Get all employees
CREATE PROCEDURE GetEmployees
AS
BEGIN
    SELECT Id, Name, Department, Email FROM Employees
END

-- Add employee
CREATE PROCEDURE AddEmployee
    @Name NVARCHAR(100),
    @Department NVARCHAR(100),
    @Email NVARCHAR(100)
AS
BEGIN
    INSERT INTO Employees (Name, Department, Email) VALUES (@Name, @Department, @Email)
END

-- Update employee
CREATE PROCEDURE UpdateEmployee
    @Id INT,
    @Name NVARCHAR(100),
    @Department NVARCHAR(100),
    @Email NVARCHAR(100)
AS
BEGIN
    UPDATE Employees SET Name=@Name, Department=@Department, Email=@Email WHERE Id=@Id
END

-- Delete employee
CREATE PROCEDURE DeleteEmployee
    @Id INT
AS
BEGIN
    DELETE FROM Employees WHERE Id=@Id
END
