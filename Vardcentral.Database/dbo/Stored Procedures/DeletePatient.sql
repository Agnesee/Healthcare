create procedure DeletePatient 
@PatientID nvarchar (128)
as
begin
delete from Patient
where PatientID=@PatientID
end;