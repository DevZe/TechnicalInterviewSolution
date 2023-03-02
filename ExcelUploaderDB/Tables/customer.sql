CREATE TABLE [dbo].[customer]
(
	[FirstName] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [LastName] VARCHAR(50) NOT NULL, 
    [DateOfBirth] DATE NOT NULL, 
    [ExcelFileUrl] NVARCHAR(2000) NOT NULL,

)
