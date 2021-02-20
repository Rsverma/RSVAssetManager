CREATE PROCEDURE [dbo].[spOrder_GetAll]
AS
	SELECT TickerSymbol, Side as OrderSide, Quantity, [Type] as OrderType, [Broker], Allocation, StopPrice, LimitPrice, AvgPrice, CommissionAndFees
    , TotalCost, TraderId, OrderDate FROM dbo.[Order]
RETURN 0
