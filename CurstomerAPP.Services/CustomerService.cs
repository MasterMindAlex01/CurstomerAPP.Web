using CurstomerAPP.Core;
using CurstomerAPP.Interfaces;
using CustomerAPP.Data.Entities;
using CustomerAPP.Data.SQLServer;
using CustomerAPP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CurstomerAPP.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DBCustomersContext _context;

        public CustomerService(DBCustomersContext context)
        {
            _context = context;
        }

        #region Customers
        public async Task<Result> GetCustomersListAsync()
        {
            var result = new Result();
            try
            {
                List<CustomerModel> customers = await _context.Customers
                    .Select(x => new CustomerModel
                    {
                        CId= x.CId,
                        CLastName1= x.CLastName1,
                        CLastName2 = x.CLastName2,
                        CName1= x.CName1,
                        CName2= x.CName2,
                    }).ToListAsync();
                result.Object = customers;
                result.Message = "Ok";
                result.IsSuccess = true;
            }
            catch (Exception)
            {
                //result.Error = ex;
                result.IsSuccess = false;
                result.Message = "La conexión a la base de datos ha fallado";
                return result;
            }
            return result;
        }

        public async Task<Result> GetCustomerByIdAsync(int cId)
        {
            var result = new Result();
            try
            {
                CustomerModel? customer = await _context.Customers
                    .Where(x => x.CId == cId)
                    .Select(x => new CustomerModel
                    {
                        CId = x.CId,
                        CLastName1 = x.CLastName1,
                        CLastName2 = x.CLastName2,
                        CName1 = x.CName1,
                        CName2 = x.CName2,
                    }).FirstOrDefaultAsync();

                result.Object = customer!;
                result.Message = "Ok";
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.IsSuccess = false;
                result.Message = "La conexión a la base de datos ha fallado";
                return result;
            }
            return result;
        }

        public async Task<Result> CreateCustomerAsync(CustomerModel model)
        {
            var result = new Result();

            var customer = new Customer
            {
                CId = model.CId,
                CLastName1 = model.CLastName1,
                CLastName2 = model.CLastName2,
                CName1 = model.CName1,
                CName2 = model.CName2,
            };

            
            try
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();

                result.Message = "Cliente creado correctamente";
                result.IsSuccess = true;
            }
            catch (Exception)
            {
                //result.Error = ex;
                result.IsSuccess = false;
                result.Message = "La creación del cliente ha fallado, por favor intentelo nuevamente";
                return result;
            }

            return result;
        }

        public async Task<Result> UpdateCustomerAsync(CustomerModel model)
        {
            var result = new Result();

            Customer? currentCustomer = await _context.Customers
                .Where(x => x.CId == model.CId).FirstOrDefaultAsync();
            if (currentCustomer == null) 
            {
                return result; 
            }

            currentCustomer.CLastName1 = model.CLastName1;
            currentCustomer.CLastName2 = model.CLastName2;
            currentCustomer.CName1 = model.CName1;
            currentCustomer.CName2 = model.CName2;

            try
            {
                await _context.SaveChangesAsync();

                result.Message = "Cliente actualizado correctamente";
                result.IsSuccess = true;
            }
            catch (Exception)
            {
                //result.Error = ex;
                result.IsSuccess = false;
                result.Message = "La actualización del cliente ha fallado, por favor intentelo nuevamente";
                return result;
            }

            return result;
        }

        public async Task<Result> DeleteCustomerAsync(int cId)
        {
            var result = new Result();

            Customer? currentCustomer = await _context.Customers
                .Where(x => x.CId == cId).FirstOrDefaultAsync();
            if (currentCustomer == null)
            {
                return result;
            }

            try
            {
                _context.Customers.Remove(currentCustomer);
                await _context.SaveChangesAsync();

                result.Message = "Cliente eliminado correctamente";
                result.IsSuccess = true;
            }
            catch (Exception)
            {
                //result.Error = ex;
                result.IsSuccess = false;
                result.Message = "La eliminación del cliente ha fallado, por favor intentelo nuevamente";
                return result;
            }

            return result;
        }
        #endregion

        #region CustomerPhones
        public async Task<Result> GetCustomerPhoneByIdAsync(int cpId)
        {
            var result = new Result();
            try
            {
                CustomersPhoneModel? customer = await _context.CustomersPhones
                    .Where(x => x.CpId == cpId)
                    .Select(x => new CustomersPhoneModel
                    {
                        CId = x.CId,
                        CpId = x.CpId,
                        CpPhone = x.CpPhone
                    }).FirstOrDefaultAsync();

                result.Object = customer!;
                result.Message = "Ok";
                result.IsSuccess = true;
            }
            catch (Exception)
            {
                //result.Error = ex;
                result.IsSuccess = false;
                result.Message = "La conexión a la base de datos ha fallado";
                return result;
            }
            return result;
        }

        public async Task<Result> GetCustomerPhonesListAsync()
        {
            var result = new Result();
            try
            {
                List<CustomersPhoneModel> customerPhones = await _context.CustomersPhones
                    .Select(x => new CustomersPhoneModel
                    {
                        CId = x.CId,
                        CpId= x.CpId,
                        CpPhone = x.CpPhone,
                    }).ToListAsync();
                result.Object = customerPhones;
                result.Message = "Ok";
                result.IsSuccess = true;
            }
            catch (Exception)
            {
                //result.Error = ex;
                result.IsSuccess = false;
                result.Message = "La conexión a la base de datos ha fallado";
                return result;
            }
            return result;
        }

        public async Task<Result> CreateCustomerPhoneAsync(CustomersPhoneModel model)
        {
            var result = new Result();

            var customerPhone = new CustomersPhone
            {
                CId = model.CId,
                CpId = model.CpId,
                CpPhone = model.CpPhone,
            };


            try
            {
                _context.CustomersPhones.Add(customerPhone);
                await _context.SaveChangesAsync();

                result.Message = "Teléfono creado correctamente";
                result.IsSuccess = true;
            }
            catch (Exception)
            {
                //result.Error = ex;
                result.IsSuccess = false;
                result.Message = "La creación del teléfono ha fallado, por favor intentelo nuevamente";
                return result;
            }

            return result;
        }

        public async Task<Result> UpdateCustomerPhoneAsync(CustomersPhoneModel model)
        {
            var result = new Result();

            CustomersPhone? currentCustomersPhone = await _context.CustomersPhones
                .Where(x => x.CpId == model.CpId).FirstOrDefaultAsync();
            if (currentCustomersPhone == null)
            {
                return result;
            }

            currentCustomersPhone.CpPhone = model.CpPhone;

            try
            {
                await _context.SaveChangesAsync();

                result.Message = "Teléfono actualizado correctamente";
                result.IsSuccess = true;
            }
            catch (Exception)
            {
                //result.Error = ex;
                result.IsSuccess = false;
                result.Message = "La actualización del teléfono ha fallado, por favor intentelo nuevamente";
                return result;
            }

            return result;
        }

        public async Task<Result> DeleteCustomerPhoneAsync(int cpId)
        {
            var result = new Result();

            CustomersPhone? currentCustomersPhone = await _context.CustomersPhones
                .Where(x => x.CpId == cpId).FirstOrDefaultAsync();
            if (currentCustomersPhone == null)
            {
                return result;
            }

            try
            {
                _context.CustomersPhones.Remove(currentCustomersPhone);
                await _context.SaveChangesAsync();

                result.Message = "Teléfono eliminado correctamente";
                result.IsSuccess = true;
            }
            catch (Exception)
            {
                //result.Error = ex;
                result.IsSuccess = false;
                result.Message = "La eliminación del teléfono ha fallado, por favor intentelo nuevamente";
                return result;
            }

            return result;
        }

        public async Task<Result> GetLastCustomerPhonesByCustomerIdAsync(int cId)
        {
            var result = new Result();
            try
            {
                List<CustomersPhoneModel> customerPhones = await _context.CustomersPhones
                    .Where(x => x.CId == cId)
                    .Select(x => new CustomersPhoneModel
                    {
                        CId = x.CId,
                        CpId = x.CpId,
                        CpPhone = x.CpPhone,
                    })
                    .OrderByDescending(x => x.CpId)
                    .Take(1)
                    .ToListAsync();
                result.Object = customerPhones;
                result.Message = "Ok";
                result.IsSuccess = true;
            }
            catch (Exception)
            {
                //result.Error = ex;
                result.IsSuccess = false;
                result.Message = "La conexión a la base de datos ha fallado";
                return result;
            }
            return result;
        }
        #endregion
    }
}
