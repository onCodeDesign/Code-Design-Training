CREATE TABLE [dbo].[Tenants] (
    [ID]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    [Key]  NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Tenants] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UK_Tenants_Key]
    ON [dbo].[Tenants]([Key] ASC);

