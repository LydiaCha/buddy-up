using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace buddy_up.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        [Required]
        [Display(Name = "Course")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Qualification Type")]
        public Qualification QualificationId { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Course description cannot be longer than 250 characters.")]
        public string Description { get; set; }
    }
}
