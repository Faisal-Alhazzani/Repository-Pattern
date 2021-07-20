using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Data;

namespace Vidly.Models.Customer
{
    public class SQLCustomrRepository : ICustomerRepository
    {
        private readonly VidlyDB context;

        public SQLCustomrRepository(VidlyDB context)
        {
            this.context = context;
        }
        public CustomerEntity Add(CustomerEntity customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            return customer;
        }

        public CustomerEntity Delete(int id)
        {
            CustomerEntity CustomerToDel = context.Customers.Find(id);
            if (CustomerToDel != null)
            {
                context.Remove(CustomerToDel);
                context.SaveChanges();
            }
            return CustomerToDel;
        }

        public CustomerEntity GetCustomer(int id)
        {
            return context.Customers.Find(id);
        }

        public IEnumerable<CustomerEntity> GetCustomers()
        {
            return context.Customers;
        }

        public CustomerEntity Update(CustomerEntity customerChanges)
        {
            var customer = context.Customers.Attach(customerChanges);
            customer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return customerChanges;
        }
    }
}
