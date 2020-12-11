using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace buddy_up.Models
{
    public class Club
    {
        public int ClubID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Club name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [Display(Name = "Type")]
        public ClubType ClubTypeId { get; set; }

        [Display(Name = "Members")]
        public ICollection<StudentClubMembership> StudentClubMemberships { get; set; }
    }
}
