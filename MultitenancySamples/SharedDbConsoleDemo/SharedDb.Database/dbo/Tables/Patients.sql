CREATE TABLE [dbo].[Patients] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50) NOT NULL,
    [DateOfBirth] DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED ([ID] ASC)
);

