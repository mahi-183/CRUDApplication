-- =============================================
-- Author:		<Author,,Mahesh Aurad>
-- Create date: <Create Date,,18July2019>
-- Description:	<Description,,Update the employee information>
-- =============================================
CREATE PROCEDURE [dbo].[UpadateEmployee]
@EmployeeId    INT,
@FirstName     NVARCHAR(50),
@LastName      NVARCHAR(50),
@Designation   NVARCHAR(50),
@Age           INT,
@Salary        INT,
@Gender        NVARCHAR(10)
AS
BEGIN
	UPDATE  Employee SET 
	FirstName = @FirstName,
	LastName = @LastName,
	Designation = @Designation ,
	Age = @Age,
	Salary = @Salary,
	Gender = @Gender
	WHERE EmployeeId = @EmployeeId
END
GO
