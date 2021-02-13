CREATE PROCEDURE [dbo].[spOrder_Insert]
	@Symbol NVARCHAR(50),
    @OrderSide int,
    @Quantity int,
    @OrderType int,
    @LimitPrice money,
    @AvgPrice money,
    @CommissionAndFees money,
    @TraderId NVARCHAR(128),
    @TradeDate datetime2
	
AS
BEGIN
	SET NOCOUNT ON;
	Insert into dbo.[Order] (TickerSymbol, Side, Quantity, Type, LimitPrice, AvgPrice, CommissionAndFees
    , TotalCost, TraderId, OrderDate)
	Values (@Symbol, @OrderSide, @Quantity, @OrderType, @LimitPrice,@AvgPrice, @CommissionAndFees
    , @CommissionAndFees + @AvgPrice,@TraderId,@TradeDate);

	Select @@IDENTITY;
END
