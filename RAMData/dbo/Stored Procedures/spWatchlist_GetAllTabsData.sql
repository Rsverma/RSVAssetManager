CREATE PROCEDURE [dbo].[spWatchlist_GetAllTabsData]
AS
	SELECT TabIndex, TabName, Index1, Index2, Index3, Index4, Index5, Index6 from WatchlistTabData
RETURN 0
