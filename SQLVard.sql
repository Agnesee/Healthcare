CREATE TABLE [dbo].[Employee](
[EmployeeId] VARCHAR IDENTITY NOT NULL,
[EmployeeName] NVARCHAR (200),
[EmployeeAddress] NVARCHAR (200),
[EmployeeTel] NVARCHAR (200),
[EmployeeTitle] NVARCHAR (200)
)

CREATE TABLE [dbo].[Patient](
[PatientId] VARCHAR IDENTITY NOT NULL,
[PatientName] NVARCHAR (200),
[PatientAddress] NVARCHAR (200),
[PatientTel] NVARCHAR (200)
)


CREATE TABLE [dbo].[Appointment](
[AppointmentId] VARCHAR IDENTITY NOT NULL,

CONSTRAINT [FK_dbo.Appointment_dbo.Employee_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([EmployeeId]) ON DELETE CASCADE,
CONSTRAINT [FK_dbo.Appointment_dbo.Patient_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[Patient] ([PatientId]) ON DELETE CASCADE,



)