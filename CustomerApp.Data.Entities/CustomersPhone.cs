using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomerAPP.Data.Entities
{
    public class CustomersPhone
    {
        public int CpId { get; set; }
        public int CId { get; set; }
        public string CpPhone { get; set; } = null!;

        public virtual Customer CIdNavigation { get; set; } = null!;
    }
}
