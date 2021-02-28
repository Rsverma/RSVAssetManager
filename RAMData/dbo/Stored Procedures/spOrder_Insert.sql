CREATE PROCEDURE [dbo].[spOrder_Insert]
    @OrigClOrderId NVARCHAR(128), 
    @ClOrderId NVARCHAR(128), 
    @StageOrderId NVARCHAR(128), 
    @InternalOrderType INT, 
    @TraderId NVARCHAR(128), 
    @OrderDate DATETIME2, 
    @Quantity INT, 
    @StopPrice MONEY, 
    @LimitPrice MONEY, 
    @AvgPrice MONEY, 
    @CommissionAndFees MONEY, 
    @TotalCost MONEY, 
    @Side CHAR, 
    @Type CHAR, 
    @TIF CHAR, 
    @OrderStatus CHAR, 
    @Broker INT, 
    @Allocation INT
	
AS
BEGIN
	SET NOCOUNT ON;
	Insert into dbo.[Order] (OrigClOrderId, ClOrderId, StageOrderId, InternalOrderType, TraderId, OrderDate, Quantity, StopPrice, LimitPrice,
    AvgPrice, CommissionAndFees, TotalCost, Side, [Type], TIF, OrderStatus, [Broker], Allocation)
	Values (@OrigClOrderId, @ClOrderId, @StageOrderId, @InternalOrderType, @TraderId, @OrderDate, @Quantity, @StopPrice, @LimitPrice,
    @AvgPrice, @CommissionAndFees, @TotalCost, @Side, @Type, @TIF, @OrderStatus, @Broker, @Allocation);

	Select @@IDENTITY;
END
