CREATE TABLE [dbo].[PatientFile] (
    [ID]           INT           IDENTITY (1, 1) NOT NULL,
    [PatientID]    INT           NOT NULL,
    [CreationDate] DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_PatientFile] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_PatientFile_Patients] FOREIGN KEY ([PatientID]) REFERENCES [dbo].[Patients] ([ID])
);

