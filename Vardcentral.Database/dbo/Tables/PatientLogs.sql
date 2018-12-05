CREATE TABLE [dbo].[PatientLogs] (
    [LogID]     INT          IDENTITY (1, 1) NOT NULL,
    [PatientID] VARCHAR (20) NULL,
    [Actions]   VARCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([LogID] ASC)
);

