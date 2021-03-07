CREATE PROCEDURE [dbo].[spWatchlist_InsertTabSymbol]
	@Key int = 0,
	@Value NVARCHAR(50)
AS
	Insert into WatchlistTabSymbol (TabIndex,Symbol)
	Values (@Key, @Value)
RETURN 0
