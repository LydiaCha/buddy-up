using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace buddy_up.Models
{
    public class ClubType
    {
        public int ClubTypeID { get; set; }

        [Required]
        [Display(Name = "Club Type")]
        [StringLength(100, ErrorMessage = "Club type cannot be longer than 100 characters.")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
