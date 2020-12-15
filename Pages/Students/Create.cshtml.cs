using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using buddy_up.Data;
using buddy_up.Models;
using Microsoft.EntityFrameworkCore;

namespace buddy_up.Pages.Students
{
    public class CreateModel : DropdownsPageModel
    {
        private readonly buddy_up.Data.ApplicationDbContext _context;

        public CreateModel(buddy_up.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var student = new Student();
            student.StudentClubMemberships = new List<StudentClubMembership>();
            PopulateAssignedClubData(_context, student);

            PopulateCoutryDropDownList(_context);
            PopulateCourseDropDownList(_context);
            return Page();
        }
        [BindProperty]
        public Student Student { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedClubs)
        {
            var emptyStudent = new Student();
 
            if (!ModelState.IsValid)
            {
                PopulateCoutryDropDownList(_context, emptyStudent.CountryId);
                PopulateCourseDropDownList(_context, emptyStudent.CourseId);
                PopulateAssignedClubData(_context, emptyStudent);
                return Page();
            }

            if (selectedClubs != null)
            {
                emptyStudent.StudentClubMemberships = new List<StudentClubMembership>();
                foreach (var club in selectedClubs)
                {
                    var clubToAdd = new StudentClubMembership
                    {
                        ClubID = int.Parse(club)
                    };
                    emptyStudent.StudentClubMemberships.Add(clubToAdd);
                }
            }

            if (await TryUpdateModelAsync<Student>(
                emptyStudent,
                "student",
                s => s.FirstName, s => s.LastName, s => s.Address, s => s.CountryId,
                s => s.CourseId,  s => s.YearOfStudy, s => s.EmailAddress, 
                s => s.DateOfBirth, s => s.TelephoneNumber
                 ))
            {
            _context.Student.Add(emptyStudent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
            }

            PopulateCoutryDropDownList(_context, emptyStudent.CountryId);
            PopulateCourseDropDownList(_context, emptyStudent.CourseId);
            PopulateAssignedClubData(_context, Student);
            return Page();
        }
    }
}
