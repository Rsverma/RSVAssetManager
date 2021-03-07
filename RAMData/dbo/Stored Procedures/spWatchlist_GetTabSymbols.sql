CREATE PROCEDURE [dbo].[spWatchlist_GetTabSymbols]
	@index int
AS
	SELECT Symbol from WatchlistTabSymbol where TabIndex = @index
RETURN 0
