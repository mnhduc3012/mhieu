using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();

        Customer GetCustomer(int id);

        void DeleteCustomer(int id);
        void UpdateCustomer(Customer customer);

        void AddCustomer(Customer customer);

        List<Customer> SearchByName(string keyword);

        Customer Login(string email, string password);
    }
}
