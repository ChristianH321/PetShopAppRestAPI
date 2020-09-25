using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Data.Repository
{
    public class CustomerRepository: ICustomerRepository
    {
        static int id = 1;
        private static List<Customer> _customers = new List<Customer>();

        public Customer Create(Customer cu)
        {
            cu.ID = id++;
            _customers.Add(cu);
            return cu;
        }

        public Customer Delete(int id)
        {
            var customerFound = this.FindCustomerbyId(id);
            if (customerFound != null)
            {
                _customers.Remove(customerFound);
                return customerFound;
            }
            return null;
        }

        public Customer FindCustomerbyId(int id)
        {
            foreach (var customer in _customers)
            {
                if (customer.ID == id)
                {
                    return customer;
                }
            }

            return null;
        }

        public void IntialiseData()
        {
            _customers = FakeDB.InitDataCustomer();
            IDAfterInit();
        }

        private void IDAfterInit()
        {
            id = FakeDB.getID();
        }

        public IEnumerable<Customer> ReadCustomers()
        {
            return _customers;
        }
    }
}
