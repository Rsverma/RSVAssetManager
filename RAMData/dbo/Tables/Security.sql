CREATE TABLE [dbo].[Security]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [TickerSymbol] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [CreateDate] DATETIME2 NOT NULL, 
    [LastModified] DATETIME2 NOT NULL
)
