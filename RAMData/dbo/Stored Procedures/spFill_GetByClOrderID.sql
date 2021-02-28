CREATE PROCEDURE [dbo].[spFill_GetByClOrderID]
	@ClOrderIDs NVARCHAR(MAX)
AS
	SELECT Id, ClOrderId, OrderId, ExecId, ExecType, OrdStatus, TickerSymbol, Side, OrderQty, LastQty, LeavesQty, CumQty, AvgPx
	From Fill --where ClOrderId in (Select value from STRING_SPLIT(@ClOrderIDs,','))
RETURN 0
