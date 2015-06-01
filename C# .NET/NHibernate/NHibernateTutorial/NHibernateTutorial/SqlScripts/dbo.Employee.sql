CREATE TABLE [dbo].[Employee]
(
	[Id]				uniqueidentifier NOT NULL,
    [Role]				NVARCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
