using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    public interface ICustomerService
    {
        Customer CreateCustomer(Customer cu);
        Customer DeleteCustomer(int id);
        List<Customer> GetCustomer();
        void InitDatabaseDataCustomer();
        Customer NewCustomer(string firstName, string lastName, DateTime birthDateOfCustomer, string adress);
        Customer UpdateCustomer(Customer customerUpdate);

    }
}
