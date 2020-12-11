using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace buddy_up.Models
{
    public class Qualification
    {
        public int QualificationID { get; set; }
        [Required]
        [Display(Name = "Qualification Type")]
        public string Name { get; set; }
    }
}
