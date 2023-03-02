using ExcelUploaderDataLibrary.Data.Models;

namespace ExcelWebApp.Data.DataEndPoint
{
    public interface ICustomerService
    {
        CustomerModel GetCustomers(string firstName);
        void SaveCustomer(CustomerModel customer);
    }
}