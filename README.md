# Excel-UploaderWebApp With .NET Core and SQL 

## A mini solution for uploading excel file and saving them in SQL databse using .NET Core and Blazor UI. 

This is a solution for uploading Excel file into a Web App using SQL database, .NET Class Library and Blazor Server App. It is constructed as a tamplate for:

* Uploading a file using Blazor FileInput
* Capturing data form HTML form using Razor syntax
* Saving and accessing data to SQL database, using a store procecdure
* Using dependency injection


 ## Check the document
<a href="https://github.com/DevZe/TechnicalInterviewSolution/blob/master/Excel%20Uploader%20Solution%20Design.pdf" target="blank">
 <a/>
 
 
 ## How to install
 
 1. Clone the repo, preferebly using Visual Studio 2022 Source Control
 2. Update the nuget packages 
 3. Open the database project and publish the database
 4. Copy the full path of the folder wwwroot/excel/customer and paste it in appsettings.json as a value for "ExcelFileStorage"

## How to contribute

Anyone willing contribute is highly welcome, since this is a mini project written as a tamplate while touching on real life solution there is room for  improvements.


## Known issues 

Since this is built from of a small design scope there is an issue of allocating a local storage for excel files because but that is currently under review for a better approach
