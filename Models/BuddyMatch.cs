using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buddy_up.Models
{
    public class BuddyMatch
    {
        public Student MentorId { get; set; }
        public Student MenteeId { get; set; }
    }
}
