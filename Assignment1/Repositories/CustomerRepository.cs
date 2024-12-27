using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public void Add(Customer x) => CustomerDAO.INSTANCE.Add(x);

        public void Delete(int id) => CustomerDAO.INSTANCE.Delete(id);

        public List<Customer> GetAll() => CustomerDAO.INSTANCE.GetAll();

        public Customer GetById(int id) => CustomerDAO.INSTANCE.GetById(id);

        public void Update(Customer x) => CustomerDAO.INSTANCE.Update(x);
    }
}
