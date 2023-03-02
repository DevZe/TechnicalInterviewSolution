CREATE PROCEDURE [dbo].[spCustomerInsert]
	    
        @FirstName VARCHAR(50),
        @LastName VARCHAR(50),
        @DateOfBirth DATETIME2(7),
        @ExcelFileUrl NVARCHAR(2000)
AS

IF NOT EXISTS(SELECT * FROM [customer] WHERE [FirstName]=@FirstName AND [LastName] = @LastName)
BEGIN
 
	INSERT INTO [customer] (FirstName,LastName,ExcelFileUrl,DateOfBirth)
    VALUES (@FirstName,@LastName,@ExcelFileUrl,@DateOfBirth)
END