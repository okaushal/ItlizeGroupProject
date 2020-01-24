CREATE TABLE [dbo].[Category] (
    [CategoryId]  INT           IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([CategoryId] ASC)
);

