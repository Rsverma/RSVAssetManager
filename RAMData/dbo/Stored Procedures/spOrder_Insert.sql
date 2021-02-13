CREATE PROCEDURE [dbo].[spOrder_Insert]
	@Symbol NVARCHAR(50),
    @OrderSide int,
    @Quantity int,
    @OrderType int,
    @LimitPrice money,
    @AvgPrice money,
    @TraderId NVARCHAR(128),
    @TradeDate datetime2
	
AS
BEGIN
	SET NOCOUNT ON;
	Insert into dbo.[Order] (TickerSymbol, Side, Quantity, Type, LimitPrice, AvgPrice, TraderId, OrderDate)
	Values (@Symbol, @OrderSide, @Quantity, @OrderType, @LimitPrice,@AvgPrice,@TraderId,@TradeDate);

	Select @@IDENTITY;
END
