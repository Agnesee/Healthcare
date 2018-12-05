CREATE TABLE [dbo].[AppointmentLogs] (
    [LogID]         INT          IDENTITY (1, 1) NOT NULL,
    [AppointmentID] INT          NULL,
    [Actions]       VARCHAR (20) NULL,
    CONSTRAINT [PK_AppointmentID] PRIMARY KEY CLUSTERED ([LogID] ASC)
);

