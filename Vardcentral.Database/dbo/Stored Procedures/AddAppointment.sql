CREATE procedure [dbo].[AddAppointment]
@DateFrom datetime, 
@DateTo datetime, 
@PatientID nvarchar (128),
@EmployeeID nvarchar (128)
as
begin
 INSERT into Appointment(DateFrom, DateTo, PatientID, EmployeeID)
 VALUES (@DateFrom, @DateTo, @PatientID, @EmployeeID)
end;