using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buddy_up.Models.BuddyUpViewModels
{
    public class AssignedClubData
    {
        public int ClubID { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }
    }
}
