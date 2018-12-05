CREATE TABLE [dbo].[Patient] (
    [PatientID] NVARCHAR (128) NOT NULL,
    [Name]      NVARCHAR (MAX) NULL,
    [Tel]       INT            NOT NULL,
    [Address]   NVARCHAR (MAX) NULL,
    [Note]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Patient] PRIMARY KEY CLUSTERED ([PatientID] ASC)
);


GO
CREATE TRIGGER [dbo].[patient_INSERT]
ON [dbo].Patient
AFTER INSERT
AS
BEGIN
SET NOCOUNT ON;
DECLARE @PatientID VARCHAR(128)
SELECT @PatientID = INSERTED.PatientId
FROM inserted
INSERT INTO PatientLogs 
VALUES (@PatientID, 'Inserted')
END
GO
create trigger t1 
on Patient
after insert
as
	begin
		select * from inserted
	end
GO
CREATE TRIGGER Addnote
on Patient
After update
as

insert into Patient (Patient.Note)
values ('Has data has been changed')