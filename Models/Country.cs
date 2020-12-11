using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace buddy_up.Models
{
    public class Country
    {
        public int CountryID { get; set; }
        [Required]
        [Display(Name= "Country")]
        public string Name { get; set; }
    }
}
