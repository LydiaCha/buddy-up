using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace buddy_up.Models
{
    public class BuddyMatch
    {
        public int BuddyMatchID { get; set; }

        [Display(Name = "Mentor")]
        public Student MentorId { get; set; }
        [Display(Name = "Mentee")]
        public Student MenteeId { get; set; }
    }
}
