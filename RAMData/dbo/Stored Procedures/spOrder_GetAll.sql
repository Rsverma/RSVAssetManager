CREATE PROCEDURE [dbo].[spOrder_GetAll]
AS
	SELECT TickerSymbol, Side, Quantity, Type, LimitPrice, AvgPrice, CommissionAndFees
    , TotalCost, TraderId, OrderDate FROM dbo.[Order]
RETURN 0
