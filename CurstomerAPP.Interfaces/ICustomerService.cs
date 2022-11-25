using CurstomerAPP.Core;
using CustomerAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurstomerAPP.Interfaces
{
    public interface ICustomerService
    {
        Task<Result> GetCustomersListAsync();
        Task<Result> GetCustomerByIdAsync(int cId);
        Task<Result> CreateCustomerAsync(CustomerModel model);
        Task<Result> UpdateCustomerAsync(CustomerModel model);
        Task<Result> DeleteCustomerAsync(int cId);

        Task<Result> GetCustomerPhonesListAsync();
        Task<Result> GetLastCustomerPhonesByCustomerIdAsync(int cId);
        Task<Result> GetCustomerPhoneByIdAsync(int cpId);
        Task<Result> CreateCustomerPhoneAsync(CustomersPhoneModel model);
        Task<Result> UpdateCustomerPhoneAsync(CustomersPhoneModel model);
        Task<Result> DeleteCustomerPhoneAsync(int cpId);
    }
}
