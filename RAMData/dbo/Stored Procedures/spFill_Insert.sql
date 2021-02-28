CREATE PROCEDURE [dbo].[spFill_Insert]
    @ClOrderId NVARCHAR(128),
    @OrderId NVARCHAR(128),
    @ExecId NVARCHAR(128),
    @ExecType CHAR(1),
    @OrdStatus CHAR(1),
    @TickerSymbol NVARCHAR(50),
    @Side CHAR(1),
    @OrderQty INT,
    @LastQty INT,
    @LeavesQty INT,
    @CumQty INT,
    @AvgPx MONEY
AS
BEGIN
	SET NOCOUNT ON;
	Insert into dbo.[Fill] (ClOrderId, OrderId, ExecId, ExecType, OrdStatus, TickerSymbol, Side, OrderQty, LastQty, LeavesQty, CumQty, AvgPx)
	Values (@ClOrderId, @OrderId, @ExecId, @ExecType, @OrdStatus, @TickerSymbol, @Side, @OrderQty, @LastQty, @LeavesQty, @CumQty, @AvgPx);

	Select @@IDENTITY;
END
