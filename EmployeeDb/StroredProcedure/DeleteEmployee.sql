-- =============================================
-- Author:		<Author,,Mahesh Aurad>
-- Create date: <Create Date,,18July2019>
-- Description:	<Description,,Delete the employee information>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteEmployee]
@EmployeeId     INT
AS
BEGIN
	DELETE FROM Employee WHERE EmployeeId = @EmployeeId;
END
GO
