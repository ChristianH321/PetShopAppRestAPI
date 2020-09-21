using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public interface ICustomerRepository
    {
        Customer Create(Customer cu);
        Customer Delete(int id);
        IEnumerable<Customer> ReadCustomers();
        void IntialiseData();
        Customer FindCustomerbyId(int id);
    }
}
