CREATE TABLE [dbo].[Product] (
    [Id]           uniqueidentifier        NOT NULL,
    [Name]         NVARCHAR (30) NULL,
    [Category]     NVARCHAR (30) NULL,
    [Discontinued] BIT        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

