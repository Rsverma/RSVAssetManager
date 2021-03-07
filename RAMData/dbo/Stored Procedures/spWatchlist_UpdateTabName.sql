CREATE PROCEDURE [dbo].[spWatchlist_UpdateTabName]
	@Key int = 0,
	@Value NVARCHAR(50)
AS
	Update WatchlistTabData
	Set TabName = @Value
	Where TabIndex = @Key
RETURN 0
