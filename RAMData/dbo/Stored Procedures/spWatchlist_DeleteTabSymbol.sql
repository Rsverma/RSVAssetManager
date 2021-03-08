CREATE PROCEDURE [dbo].[spWatchlist_DeleteTabSymbol]
	@Key int = 0,
	@Value NVARCHAR(50)
AS
	Delete From WatchlistTabSymbol Where TabIndex = @Key and Symbol = @Value
RETURN 0