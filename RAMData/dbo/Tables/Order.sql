CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TickerSymbol] NVARCHAR(50) NOT NULL, 
    [TraderId] NVARCHAR(128) NOT NULL, 
    [OrderDate] DATETIME2 NOT NULL, 
    [Quantity] INT NOT NULL DEFAULT 1, 
    [LimitPrice] MONEY NOT NULL, 
    [AvgPrice] MONEY NOT NULL, 
    [CommissionAndFees] MONEY NOT NULL DEFAULT 0, 
    [TotalCost] MONEY NOT NULL, 
    [Side] INT NOT NULL, 
    [Type] INT NOT NULL
)
