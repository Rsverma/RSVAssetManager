CREATE PROCEDURE [dbo].[spBroker_GetAll]
AS
	SELECT Id, [Name] FROM dbo.[Broker]
RETURN 0
