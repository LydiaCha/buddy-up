﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace buddy_up.Models
{
    public class Student
    {

        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public Country CountryId { get; set; }

        public Course CourseId { get; set; }
        public int YearOfStudy { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }
        public ICollection<StudentClubMembership> StudentClubMemberships { get; set; }

    }
}
