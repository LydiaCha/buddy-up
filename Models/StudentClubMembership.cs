﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace buddy_up.Models
{
    public class StudentClubMembership
    {
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int ClubID { get; set; }
        
        public Club Club { get; set; }
    }
}
