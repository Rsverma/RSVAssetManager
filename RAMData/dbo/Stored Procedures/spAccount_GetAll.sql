CREATE PROCEDURE [dbo].[spAccount_GetAll]
AS
	SELECT Id, [Name] FROM dbo.[Account]
RETURN 0
