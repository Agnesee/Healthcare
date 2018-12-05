CREATE TABLE [dbo].[Appointment] (
    [AppointmentID] INT            IDENTITY (1, 1) NOT NULL,
    [DateFrom]      DATETIME       NOT NULL,
    [DateTo]        DATETIME       NOT NULL,
    [PatientID]     NVARCHAR (128) NULL,
    [EmployeeID]    NVARCHAR (128) NULL,
    CONSTRAINT [PK_dbo.Appointment] PRIMARY KEY CLUSTERED ([AppointmentID] ASC),
    CONSTRAINT [FK_dbo.Appointment_dbo.Employee_EmployeeID] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID]),
    CONSTRAINT [FK_dbo.Appointment_dbo.Patient_PatientID] FOREIGN KEY ([PatientID]) REFERENCES [dbo].[Patient] ([PatientID])
);


GO
CREATE NONCLUSTERED INDEX [IX_EmployeeID]
    ON [dbo].[Appointment]([EmployeeID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PatientID]
    ON [dbo].[Appointment]([PatientID] ASC);


GO
CREATE TRIGGER [dbo].[Appointment_INSERT]
ON [dbo].Appointment
AFTER INSERT
AS
BEGIN
SET NOCOUNT ON;
DECLARE @AppointmentID int
SELECT @AppointmentID = INSERTED.AppointmentID
FROM inserted
INSERT INTO AppointmentLogs (appointmentid, actions)
VALUES (@AppointmentID, 'Inserted')
END