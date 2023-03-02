CREATE PROCEDURE [dbo].[spCustomerLookUp]
--query a customer by first name	
	@firstName VARCHAR(50)
AS
BEGIN
	SELECT * FROM [customer]
	WHERE [FirstName] = @firstName
END
