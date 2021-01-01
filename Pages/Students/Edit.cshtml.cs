using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using buddy_up.Data;
using buddy_up.Models;

namespace buddy_up.Pages.Students
{
    public class EditModel : DropdownsPageModel
    {
        private readonly buddy_up.Data.ApplicationDbContext _context;

        public EditModel(buddy_up.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }
        public BuddyMatch BuddyMatch { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Student
                .Include(s => s.StudentClubMemberships).ThenInclude(s => s.Club)
                .FirstOrDefaultAsync(m => m.StudentID == id);

            BuddyMatch = await _context.BuddyMatch.Include(bm => bm.Mentee).Include(bm => bm.Mentor)
.FirstOrDefaultAsync(bm => bm.MenteeId == id || bm.MentorId == id);

            if (Student == null)
            {
                return NotFound();
            }

            PopulateCoutryDropDownList(_context, Student.CountryId);
            PopulateCourseDropDownList(_context, Student.CourseId);
            PopulateAssignedClubData(_context, Student);
            PopulateStudentDropDownList(_context, BuddyMatch.BuddyMatchID);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedClubs)
        {
            var studentToUpdate = await _context.Student.Include(s => s.StudentClubMemberships).ThenInclude(s => s.Club)
                .FirstOrDefaultAsync(m => m.StudentID == id);

            var matchToUpdate = await _context.BuddyMatch.Include(bm => bm.Mentee).Include(bm => bm.Mentor)
.FirstOrDefaultAsync(bm => bm.MenteeId == id || bm.MentorId == id);

            var buddyMatchMentor = await _context.BuddyMatch.Where(bmm => bmm.MentorId == id)
.ToListAsync();

            var buddyMatchMentee = await _context.BuddyMatch.Where(bmm => bmm.MenteeId == id)
    .ToListAsync();

            if (!ModelState.IsValid)
            {
                PopulateCoutryDropDownList(_context, studentToUpdate.CountryId);
                PopulateCourseDropDownList(_context, studentToUpdate.CourseId);
                PopulateAssignedClubData(_context, studentToUpdate);
                PopulateStudentDropDownList(_context, matchToUpdate.BuddyMatchID);
                return Page();
            }

            if (await TryUpdateModelAsync<Student>(
                 studentToUpdate,
                "student",
                s => s.FirstName, s => s.LastName, s => s.Address, s => s.CountryId,
                s => s.CourseId, s => s.YearOfStudy, s => s.EmailAddress,
                s => s.DateOfBirth, s => s.TelephoneNumber
                   ))
            {

                buddyMatchMentor.ForEach(bmm => bmm.MentorId = null);
                buddyMatchMentee.ForEach(bmm => bmm.MenteeId = null);

                _context.BuddyMatch.Remove(matchToUpdate);

                var buddyFormResult = Request.Form["buddy"];
                Int32.TryParse(buddyFormResult, out int buddyId);
                
                var buddyMatch = new BuddyMatch { Mentee = studentToUpdate, Mentor = _context.Student.SingleOrDefault(s => s.StudentID == buddyId) };
             
                _context.BuddyMatch.Add(buddyMatch);

                UpdateStudentClubs(_context, selectedClubs, studentToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateStudentClubs(_context, selectedClubs, studentToUpdate);
            PopulateCoutryDropDownList(_context, studentToUpdate.CountryId);
            PopulateCourseDropDownList(_context, studentToUpdate.CourseId);
            PopulateAssignedClubData(_context, studentToUpdate);
            PopulateStudentDropDownList(_context, matchToUpdate.BuddyMatchID);
            return Page();
        }
        }
}
