CREATE PROCEDURE [dbo].[spOrder_Insert]
	@TickerSymbol NVARCHAR(50),
    @OrderSide int,
    @Quantity int,
    @OrderType int,
    @LimitPrice money,
    @AvgPrice money,
    @CommissionAndFees money,
    @TraderId NVARCHAR(128),
    @OrderDate datetime2
	
AS
BEGIN
	SET NOCOUNT ON;
	Insert into dbo.[Order] (TickerSymbol, Side, Quantity, Type, LimitPrice, AvgPrice, CommissionAndFees
    , TotalCost, TraderId, OrderDate)
	Values (@TickerSymbol, @OrderSide, @Quantity, @OrderType, @LimitPrice,@AvgPrice, @CommissionAndFees
    , @CommissionAndFees + @AvgPrice,@TraderId,@OrderDate);

	Select @@IDENTITY;
END
