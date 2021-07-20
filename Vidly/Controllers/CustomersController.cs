using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Data;
using Vidly.Models;
using Vidly.Models.Customer;

namespace Vidly.Views
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            var CustomersList = customerRepository.GetCustomers().ToList();
            var CustomerVM = CustomersList.Select(c => new CustomerViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                Age=c.Age,
                phone=c.phone
            }).ToList();
            return View("Customers", CustomerVM);
        }

        public IActionResult Detailes(int id)
        {
            var CustomersList = customerRepository.GetCustomers().ToList();
            var FondCustomer = CustomersList.Find(c => c.Id == id);
            if (FondCustomer == null)
            {
                return NotFound();
            }

            var DetailesVM = new DetailesViewModel()
            {
                Name = FondCustomer.Name,
                Id = FondCustomer.Id,
                phone = FondCustomer.phone,
                Age = FondCustomer.Age
            };
            return View(DetailesVM);
        }


    }
}
