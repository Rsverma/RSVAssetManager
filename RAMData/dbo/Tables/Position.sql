CREATE TABLE [dbo].[Holding]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [TickerSymbol] NVARCHAR(50) NOT NULL, 
    [Quantity] INT NOT NULL DEFAULT 1, 
    [SubTotal] MONEY NOT NULL, 
    [CommissionAndFee] MONEY NOT NULL DEFAULT 0 , 
    [Total] MONEY NOT NULL

)
