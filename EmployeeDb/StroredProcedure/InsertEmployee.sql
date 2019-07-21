-- =============================================
-- Author:		<Author,,Mahesh Aurad>
-- Create date: <Create Date,,18July2019>
-- Description:	<Description,,Add the employee information>
-- =============================================
CREATE PROCEDURE [dbo].[InsertEmployee]

@FirstName        NVARCHAR(50),
@LastName         NVARCHAR(50),
@Designation      NVARCHAR(50),
@Age              INT,
@Salary           INT,
@Gender           NVARCHAR(10)
AS
BEGIN
	INSERT INTO Employee(
	                     FirstName,
						 LastName,
						 Designation,
						 Age,
						 Salary,
						 Gender)
				  VALUES(
				         @FirstName,
					     @LastName,
					     @Designation,
					     @Age,
					     @Salary,
					     @Gender)
END
GO