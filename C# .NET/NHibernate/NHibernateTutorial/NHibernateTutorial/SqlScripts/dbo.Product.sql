CREATE TABLE [dbo].[Product] (
    [Id]           uniqueidentifier        NOT NULL,
    [Name]         NCHAR (30) NULL,
    [Category]     NCHAR (30) NULL,
    [Discontinued] BIT        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

