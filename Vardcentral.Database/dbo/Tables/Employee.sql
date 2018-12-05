CREATE TABLE [dbo].[Employee] (
    [EmployeeID] NVARCHAR (128) NOT NULL,
    [Title]      NVARCHAR (MAX) NULL,
    [Name]       NVARCHAR (MAX) NULL,
    [Address]    NVARCHAR (MAX) NULL,
    [Tel]        INT            NOT NULL,
    CONSTRAINT [PK_dbo.Employee] PRIMARY KEY CLUSTERED ([EmployeeID] ASC)
);

