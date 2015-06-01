CREATE TABLE [dbo].[Person]
(
	[Id]				uniqueidentifier NOT NULL,
    [FirstName]			NVARCHAR (30) NULL,
    [LastName]			NVARCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
