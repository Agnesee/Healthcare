CREATE procedure [dbo].[GetAppointmentsByEmployeeId] @EmployeeId nvarchar(128)
AS
BEGIN
	SELECT * 
	FROM dbo.Appointment 
	WHERE EmployeeID = @EmployeeId
END