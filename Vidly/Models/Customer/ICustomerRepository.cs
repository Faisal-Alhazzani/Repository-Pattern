using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Models.Customer
{
    public interface ICustomerRepository
    {
        CustomerEntity GetCustomer(int id);
        IEnumerable<CustomerEntity> GetCustomers();
        CustomerEntity Add(CustomerEntity customer);
        CustomerEntity Update(CustomerEntity customerChanges);
        CustomerEntity Delete(int id);
    }
}
