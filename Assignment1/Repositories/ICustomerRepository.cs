using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();

        Customer GetById(int id);

        void Add(Customer x);

        void Update(Customer x);

        void Delete(int id);

    }
}
