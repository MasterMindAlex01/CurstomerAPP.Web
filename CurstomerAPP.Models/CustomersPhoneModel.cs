using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomerAPP.Models
{
    public class CustomersPhoneModel
    {
        [Required]
        public int CpId { get; set; }
        [Required]
        public int CId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string CpPhone { get; set; } = null!;
    }
}
