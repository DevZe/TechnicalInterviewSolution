using ExcelUploaderDataLibrary.Data.Models;
using ExcelUploaderDataLibrary.DataAccess;

namespace ExcelWebApp.Data.DataEndPoint
{
    /// <summary>
    /// This is a class for handling customer data end points 
    /// </summary>
    public class CustomerService : ICustomerService
    {

        private readonly ISQLDataAccess _dataAccess;

        public CustomerService(ISQLDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        //Insert a customer
        public void SaveCustomer(CustomerModel customer)
        {
            if (customer != null)
            {
                try
                {
                    //Insert model data
                    _dataAccess.SaveData<CustomerModel>("spCustomerInsert", customer, "Default");
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message, ex.InnerException);
                }
            }
        }

        //Get a single customer parameter
        public CustomerModel GetCustomers(string firstName)
        {

            try
            {
                if (!string.IsNullOrWhiteSpace(firstName))
                {
                    //Query the database by customer name
                    var customers = _dataAccess.LoadData<CustomerModel, dynamic>("spCustomerLookUp", new { firstName = firstName }, "Default").FirstOrDefault();
                    return customers;
                }


            }
            catch (Exception)
            {

                throw;
            }

            return null;
        }
    }
}
