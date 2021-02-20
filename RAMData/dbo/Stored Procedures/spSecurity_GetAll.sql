CREATE PROCEDURE [dbo].[spSecurity_GetAll]
AS
	SELECT [Id], [TickerSymbol], [Description], [CreateDate], [LastModified] FROM dbo.[Security]
RETURN 0
