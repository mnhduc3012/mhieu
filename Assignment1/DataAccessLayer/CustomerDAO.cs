using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        public static CustomerDAO INSTANCE = new();

        public CustomerDAO()
        {
            if (INSTANCE == null) INSTANCE = this;
        }

        private List<Customer> list = new List<Customer>
        {
            new Customer { CustomerID = 1, CustomerFullName = "William Shakespeare", Telephone = "0903939393", EmailAddress = "WilliamShakespeare@FUMiniHotel.org", CustomerBirthday = DateOnly.Parse("1990-02-02"), CustomerStatus = 1, Password = "123@" },
            new Customer { CustomerID = 2, CustomerFullName = "Elizabeth Taylor", Telephone = "0903939377", EmailAddress = "ElizabethTaylor@FUMiniHotel.org", CustomerBirthday = DateOnly.Parse("1991-03-03"), CustomerStatus = 1, Password = "123@" },
            new Customer { CustomerID = 3, CustomerFullName = "James Cameron", Telephone = "0903946582", EmailAddress = "JamesCameron@FUMiniHotel.org", CustomerBirthday = DateOnly.Parse("1992-11-10"), CustomerStatus = 1, Password = "123@" }
        };

        public List<Customer> GetAll()
        {
            return list;
        }

        public Customer GetById(int id)
        {

            foreach (var o in list)
            {
                if (o.CustomerID == id)
                {
                    return o;
                }
            }
            return null;
        }

        public void Add(Customer x)
        {
            list.Add(x);
        }

        public void Update(Customer x)
        {

            foreach (var o in list)
            {
                if (o.CustomerID == x.CustomerID)
                {
                    o.CustomerFullName = x.CustomerFullName;
                    o.Telephone = x.Telephone;
                    o.EmailAddress = x.EmailAddress;
                    o.CustomerBirthday = x.CustomerBirthday;
                    o.CustomerStatus = x.CustomerStatus;
                    o.Password = x.Password;

                }
            }

        }

        public void Delete(int id)
        {
            var o = GetById(id);
            list.Remove(o);

        }

    }
}
