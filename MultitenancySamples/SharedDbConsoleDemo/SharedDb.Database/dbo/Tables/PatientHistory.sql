CREATE TABLE [dbo].[PatientHistory] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [PatientFileID]    INT            NOT NULL,
    [DiagnosticID]     INT            NOT NULL,
    [EntryDescription] NVARCHAR (500) NOT NULL,
    [EntryDate]        DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_PatientHistory] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_PatientHistory_Diagnostics] FOREIGN KEY ([DiagnosticID]) REFERENCES [dbo].[Diagnostics] ([ID]),
    CONSTRAINT [FK_PatientHistory_PatientFile] FOREIGN KEY ([PatientFileID]) REFERENCES [dbo].[PatientFile] ([ID])
);

