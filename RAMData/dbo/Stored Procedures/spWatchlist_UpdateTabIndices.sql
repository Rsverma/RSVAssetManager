CREATE PROCEDURE [dbo].[spWatchlist_UpdateTabIndices]
	@TabIndex int,
	@Index1 NVARCHAR(50),
	@Index2 NVARCHAR(50),
	@Index3 NVARCHAR(50),
	@Index4 NVARCHAR(50),
	@Index5 NVARCHAR(50),
	@Index6 NVARCHAR(50)
AS
	Update WatchlistTabData
	Set Index1 = @Index1, Index2 = @Index2, Index3 = @Index3,
	Index4 = @Index4, Index5 = @Index5, Index6 = @Index6
	Where TabIndex = @TabIndex
RETURN 0
