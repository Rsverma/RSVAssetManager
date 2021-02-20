CREATE PROCEDURE [dbo].[spOrder_Insert]
	@TickerSymbol NVARCHAR(50),
    @OrderSide int,
    @Quantity int,
    @OrderType int,
    @Broker int,
    @Allocation int,
    @StopPrice money,
    @LimitPrice money,
    @AvgPrice money,
    @CommissionAndFees money,
    @TraderId NVARCHAR(128),
    @OrderDate datetime2
	
AS
BEGIN
	SET NOCOUNT ON;
	Insert into dbo.[Order] (TickerSymbol, Side, Quantity, [Type], [Broker], Allocation, StopPrice, LimitPrice, AvgPrice, CommissionAndFees
    , TotalCost, TraderId, OrderDate)
	Values (@TickerSymbol, @OrderSide, @Quantity, @OrderType, @Broker, @Allocation, @StopPrice, @LimitPrice,@AvgPrice, @CommissionAndFees
    , @CommissionAndFees + @AvgPrice,@TraderId,@OrderDate);

	Select @@IDENTITY;
END
