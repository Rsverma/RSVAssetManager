CREATE TABLE [dbo].[Fill]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ClOrderId] NVARCHAR(128) NOT NULL,
    [OrderId] NVARCHAR(128) NOT NULL,
    [ExecId] NVARCHAR(128) NOT NULL,
    [ExecType] CHAR(1) NOT NULL,
    [OrdStatus] CHAR(1) NOT NULL,
    [TickerSymbol] NVARCHAR(50) NOT NULL,
    [Side] CHAR(1) NOT NULL,
    [OrderQty] INT NOT NULL,
    [LastQty] INT NOT NULL,
    [LeavesQty] INT NOT NULL,
    [CumQty] INT NOT NULL,
    [AvgPx] MONEY NOT NULL,
)
