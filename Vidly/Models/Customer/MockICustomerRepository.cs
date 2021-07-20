using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Models.Customer
{
    public class MockICustomerRepository : ICustomerRepository
    {
        private List<CustomerEntity> _customers;
        public MockICustomerRepository()
        {
            _customers = new List<CustomerEntity>() {
            new CustomerEntity(){ Id=1, Name="Faisal", phone="05555546135", Age=25, IsSubscribedToNewsLetter=false},
            new CustomerEntity(){ Id=2, Name="Ali", phone="05675546225", Age=45, IsSubscribedToNewsLetter=true}
            };
        }

        public CustomerEntity Add(CustomerEntity customer)
        {
            customer.Id = _customers.Max(c => c.Id) + 1;
            _customers.Add(customer);
            return customer;
        }

        public CustomerEntity Delete(int id)
        {
            CustomerEntity CustomerToDel = _customers.FirstOrDefault(c => c.Id == id);
            if (CustomerToDel != null)
            {
                _customers.Remove(CustomerToDel);
            }
            return CustomerToDel;
        }

        public CustomerEntity GetCustomer(int id)
        {
            return _customers.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<CustomerEntity> GetCustomers()
        {
            return _customers;
        }

        public CustomerEntity Update(CustomerEntity customerChanges)
        {
            CustomerEntity customer = _customers.SingleOrDefault(c => c.Id == customerChanges.Id);
            if (customer != null) {
                customer.Name = customerChanges.Name;
                customer.phone = customerChanges.phone;
                customer.Age = customerChanges.Age;
            }
            return customer;
        }
    }
}
