using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    public class CustomerService: ICustomerService
    {

        private ICustomerRepository _customerRepo;

        public CustomerService(ICustomerRepository perReposit)
        {
            _customerRepo = perReposit;
        }

        public Customer CreateCustomer(Customer cu)
        {
            return _customerRepo.Create(cu);
        }

        public Customer DeleteCustomer(int id)
        {
            return _customerRepo.Delete(id);
        }

        public List<Customer> GetCustomer()
        {
            return _customerRepo.ReadCustomers().ToList();
        }

        public void InitDatabaseDataCustomer()
        {
            _customerRepo.IntialiseData();
        }

        public Customer NewCustomer(string firstName, string lastName, DateTime birthDateOfCustomer, string adress)
        {
            var cu = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDateOfCustomer = birthDateOfCustomer,
                Adress = adress,
            };

            return cu;
        }

        public Customer FindCustomerById(int id)
        {
            return _customerRepo.FindCustomerbyId(id);
        }

        public Customer UpdateCustomer(Customer customerUpdate)
        {
            var customer = FindCustomerById(customerUpdate.ID);
            customer.FirstName = customerUpdate.LastName;
            customer.LastName = customerUpdate.LastName;
            customer.BirthDateOfCustomer = customerUpdate.BirthDateOfCustomer;
            customer.Adress = customerUpdate.Adress;
            return customer;
        }
    }
}
