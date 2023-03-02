
namespace ExcelWebApp.Models;

/// <summary>
/// This class is a model that represents the 'Income and Expense' data record from Excel file
/// Each property is a column
/// </summary>
public class MonthlyFinanceModel
{
    public string? Month { get; set; }
    public float income { get; set; }
    public float Expenses { get; set; }
}
