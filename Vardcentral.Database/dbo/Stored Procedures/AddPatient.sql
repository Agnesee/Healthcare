create procedure AddPatient
@PatientID nvarchar (128),
@Name nvarchar (max), 
@Tel int, 
@Address nvarchar (max)
as
begin
 INSERT into Patient(PatientID, Name, Tel, Address)
 VALUES (@PatientID, @Name, @Tel, @Address)
end;