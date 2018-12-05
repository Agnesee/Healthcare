CREATE procedure [dbo].[GetAppointmentsByPatientId] @PatientId nvarchar(128)
AS
BEGIN
	SELECT * 
	FROM dbo.Appointment 
	WHERE PatientID = @PatientId
END

select * from Patient