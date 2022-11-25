using System;
using System.Collections.Generic;

namespace CustomerAPP.Data.Entities
{
    public class Customer
    {
        public Customer()
        {
            CustomersPhones = new HashSet<CustomersPhone>();
        }

        public int CId { get; set; }
        public string CName1 { get; set; } = null!;
        public string? CName2 { get; set; }
        public string CLastName1 { get; set; } = null!;
        public string? CLastName2 { get; set; }

        public virtual ICollection<CustomersPhone> CustomersPhones { get; set; }
    }
}
