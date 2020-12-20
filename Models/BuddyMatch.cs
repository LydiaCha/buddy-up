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
        public int? MentorId { get; set; }
        public Student Mentor { get; set; }
        [Display(Name = "Mentee")]
        public int? MenteeId { get; set; }
        public Student Mentee { get; set; }
    }
}
