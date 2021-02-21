CREATE PROCEDURE [dbo].[spOrder_GetAll]
AS
	SELECT TickerSymbol, Side as OrderSide, Quantity, [Type] as OrderType, TIF, OrderStatus, [Broker], Allocation, StopPrice, LimitPrice, AvgPrice, CommissionAndFees
    , TotalCost, TraderId, OrderDate FROM dbo.[Order]
RETURN 0
