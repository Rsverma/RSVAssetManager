CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TickerSymbol] NVARCHAR(50) NOT NULL, 
    [TraderId] NVARCHAR(128) NOT NULL, 
    [OrderDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [Quantity] INT NOT NULL DEFAULT 1, 
    [StopPrice] MONEY NOT NULL DEFAULT 0, 
    [LimitPrice] MONEY NOT NULL DEFAULT 0, 
    [AvgPrice] MONEY NOT NULL, 
    [CommissionAndFees] MONEY NOT NULL DEFAULT 0, 
    [TotalCost] MONEY NOT NULL, 
    [Side] CHAR NOT NULL DEFAULT '1', 
    [Type] CHAR NOT NULL DEFAULT '1', 
    [TIF] CHAR NOT NULL DEFAULT '0', 
    [OrderStatus] CHAR NOT NULL DEFAULT '2', 
    [Broker] INT NOT NULL DEFAULT 0, 
    [Allocation] INT NOT NULL DEFAULT 0
)
