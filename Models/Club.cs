﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buddy_up.Models
{
    public class Club
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ClubType ClubTypeId { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}