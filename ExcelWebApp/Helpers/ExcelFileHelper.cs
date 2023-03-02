using ExcelWebApp.Models;
using Microsoft.AspNetCore.Components.Forms;
using OfficeOpenXml;

namespace ExcelWebApp.Helpers;


public class ExcelFileHelper
{
    IConfiguration _config;
    public float[] y1Values;//income
    public float[] y2Values;//expenses
    public string[] xValues;//months
    List<string> Errors = new List<string>();


    public ExcelFileHelper(IConfiguration config)
    {
        _config = config;
    }

    //Populate the values of chart parameters 
    public void GetChartData(List<MonthlyFinanceModel> yearFinanceStatement)
    {

        List<float> expenses = new();
        List<float> incomes = new();
        List<string>? Months = new();

        if (yearFinanceStatement != null)
        {
            foreach (var month in yearFinanceStatement)
            {
                expenses.Add(month.Expenses);
                incomes.Add(month.income);
                Months.Add(month.Month);
            }
        }


        y1Values = incomes.ToArray();
        y2Values = expenses.ToArray();
        xValues = Months.ToArray();
    }


    private readonly long maxFileSize = 1024 * 1024 * 2; //2 megabytes , max file size
    //Number of files allowd
    private readonly int maxAllowedFiles = 1;
    //Absolute file path
    public string? excelFilePath;
    FileInfo fileInfo;



    /// <summary>
    /// Upload the excel file using InputFile into the system
    /// </summary>
    /// <param name="args">Asynchronous Task</param>
    /// <returns></returns>
    public async Task LoadExcelFile(InputFileChangeEventArgs args)
    {
        Errors.Clear();
        IBrowserFile file = args.File;

        if (file == null)
        {
            return;
        }
        //Minimizing the number of files allowed
        if (args.FileCount > maxAllowedFiles)
        {
            Errors.Add($"Error: Attempting to upload {args.FileCount} files, but only {maxAllowedFiles} files are allowed");
        }
        try
        {

            //new file name 
            string newFileName = Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(file.Name));

            //file absolute path
            excelFilePath = Path.Combine(_config.GetValue<string>("ExcelFileStorage")!, "customer", newFileName);
            //relative relative path
            var relativePath = Path.Combine("customer", newFileName);
            Directory.CreateDirectory(Path.Combine(_config.GetValue<string>("ExcelFileStorage")!, "customer"));

            await using FileStream fs = new(excelFilePath, FileMode.CreateNew);
            await file.OpenReadStream(maxFileSize).CopyToAsync(fs);
        }
        catch (Exception ex)
        {

            Errors.Add($"File: {file.Name} Error: {ex.Message}");
            throw;
        }

    }


    /// <summary>
    ///  Read data from excel file using EPPlus Package
    ///  Read per cell of a worksheet
    /// </summary>
    /// <param name="url">Excel file path</param>
    /// <returns>List of Monthly Finance Model (12 months income and expenses) </returns>
    /// <exception cref="Exception"></exception>
    public List<MonthlyFinanceModel>? ReadExcelFile(string url)
    {
        List<MonthlyFinanceModel>? customerExpenses = new()!;
        try
        {
            if (!string.IsNullOrWhiteSpace(url))
            {

                fileInfo = new FileInfo(url);

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet? worksheet = excelPackage.Workbook.Worksheets.FirstOrDefault();
                    int lastColumn = worksheet.Dimension.End.Column;
                    int lastRow = worksheet.Dimension.End.Row;


                    for (int row = 2; row <= lastRow; row++)
                    {
                        MonthlyFinanceModel monthlyFinanceModel = new MonthlyFinanceModel();


                        for (int col = 1; col <= lastColumn; col++)
                        {
                            if (col == 1) monthlyFinanceModel.Month = worksheet.Cells[row, col].Value.ToString();
                            if (col == 2) monthlyFinanceModel.income = float.Parse(worksheet.Cells[row, col].Value.ToString());
                            if (col == 3) monthlyFinanceModel.Expenses = float.Parse(worksheet.Cells[row, col].Value.ToString());


                        }
                        customerExpenses.Add(monthlyFinanceModel);
                    }
                }
                return customerExpenses;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
        return null;
    }


    //Loading data to Monthly-Finance-Model list as a 12 months Income and Expenses
    public List<MonthlyFinanceModel>? LoadDataFromFile(string path)
    {
        try
        {
            //Read the excel file using the given path
            if (path != null)
            {
                var yearFinanceStatement = ReadExcelFile(path);
                return yearFinanceStatement;
            }

        }
        catch (Exception ex)
        {

            Errors.Add(ex.Message);
            throw;
        }
        return null;
    }
}
