using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buddy_up.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public Qualification QualificationId { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
    }
}
