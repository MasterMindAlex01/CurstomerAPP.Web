using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomerAPP.Models
{
    public class CustomerModel
    {

        [Required]
        public int CId { get; set; }
        [Required]
        [StringLength(30,MinimumLength =3)]
        public string CName1 { get; set; } = null!;

        [StringLength(30)]
        public string? CName2 { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string CLastName1 { get; set; } = null!;

        [StringLength(30)]
        public string? CLastName2 { get; set; }
    }
}
