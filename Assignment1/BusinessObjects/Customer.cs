using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string? CustomerFullName { get; set; }

        public string? Telephone { get; set; }

        public string? EmailAddress { get; set; }

        public DateOnly? CustomerBirthday { get; set; }

        public int CustomerStatus { get; set; }

        public virtual string Status
        {
            get => CustomerStatus == 1 ? "Active" : "Deleted";
        }

        public string? Password { get; set; }
    }
}
