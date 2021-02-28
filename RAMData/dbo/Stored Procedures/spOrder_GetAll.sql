CREATE PROCEDURE [dbo].[spOrder_GetAll]
AS
	SELECT Id, OrigClOrderId, ClOrderId, StageOrderId, InternalOrderType, TraderId, OrderDate, Quantity, StopPrice, LimitPrice,
    AvgPrice, CommissionAndFees, TotalCost, Side, [Type], TIF, OrderStatus, [Broker], Allocation FROM dbo.[Order]
RETURN 0
