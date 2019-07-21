CREATE TABLE [dbo].[Employee]
(
	[EmployeeId] INT IDENTITY(1,1) PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Designation] NVARCHAR(50) NOT NULL, 
    [Age] INT NOT NULL, 
    [Salary] INT NOT NULL, 
    [Gender] NCHAR(10) NOT NULL
)
