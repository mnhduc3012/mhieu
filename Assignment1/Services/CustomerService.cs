using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        public Customer GetCustomer(int id) => _customerRepository.GetById(id);

        public List<Customer> GetCustomers() => _customerRepository.GetAll();

        public void DeleteCustomer(int id) => _customerRepository.Delete(id);

        public void UpdateCustomer(Customer customer) => _customerRepository.Update(customer);

        public void AddCustomer(Customer customer) => _customerRepository.Add(customer);

        public List<Customer> SearchByName(string? keyword)
        {
            List<Customer> result = _customerRepository.GetAll();

            if (keyword != null)
            {
                result = result.Where(x => x.CustomerFullName.ToLower().Contains(keyword.ToLower())).ToList();
            }
            return result;
        }

        public Customer? Login(string email, string password)
        {
            return _customerRepository.GetAll().Where(x => x.EmailAddress.Equals(email) && x.Password.Equals(password)).FirstOrDefault();
        }
    }
}
