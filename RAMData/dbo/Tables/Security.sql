CREATE TABLE [dbo].[Security]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TickerSymbol] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [CreateDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [LastModified] DATETIME2 NOT NULL DEFAULT getutcdate()
)
