
namespace ExcelUploaderDataLibrary.Data.Models;
/// <summary>
/// This is a record of a Customer
/// </summary>
public class CustomerModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? ExcelFileUrl { get; set; }


}
