CREATE TABLE [dbo].[WatchlistTabSymbol]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TabIndex] INT NOT NULL, 
    [Symbol] NVARCHAR(50) NOT NULL
)
