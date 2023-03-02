using ExcelWebApp.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace ExcelWebApp.Data.DataEndPoint
{
    public interface IExcelFileHelper
    {
        Task getChartData(List<MonthlyFinanceModel> yearFinanceStatement);
        List<MonthlyFinanceModel>? LoadDataFromFile(string path);
        Task LoadExcelFile(InputFileChangeEventArgs args);
        List<MonthlyFinanceModel>? ReadExcelFile(string url);
    }
}