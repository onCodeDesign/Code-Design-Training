CREATE TABLE [dbo].[Diagnostics] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (500) NULL,
    [Description] NVARCHAR (500) NULL,
    [Simptoms]    NVARCHAR (50)  NULL,
    CONSTRAINT [PK_Diagnostics] PRIMARY KEY CLUSTERED ([ID] ASC)
);

