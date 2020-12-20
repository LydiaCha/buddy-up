using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using buddy_up.Data;
using buddy_up.Models;

namespace buddy_up.Pages.Students
{
    public class DeleteModel : DropdownsPageModel
    {
        private readonly buddy_up.Data.ApplicationDbContext _context;

        public DeleteModel(buddy_up.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }
        public IList<BuddyMatch> BuddyMatch { get; set; }
        public Student Buddy { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
                           
            BuddyMatch = await _context.BuddyMatch
                    .Include(bm => bm.Mentee)
                    .Include(bm => bm.Mentor)
                    .AsNoTracking()
                    .ToListAsync();

            Student = await _context.Student
                   .Include(s => s.Country)
                   .Include(s => s.Course)
                   .Include(s => s.StudentClubMemberships)
                       .ThenInclude(s => s.Club)
                   .SingleAsync(s => s.StudentID == id);

            foreach (var entry in BuddyMatch)
            {
                if (entry.MentorId == Student.StudentID)
                { Buddy = await _context.Student.SingleOrDefaultAsync(s => s.StudentID == entry.MenteeId); }
                else if (entry.MenteeId == Student.StudentID)
                { Buddy = await _context.Student.SingleOrDefaultAsync(s => s.StudentID == entry.MentorId); }
                else
                { Buddy = null; }
            }

            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Student.FirstOrDefaultAsync(m => m.StudentID == id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

        if (Student != null)
            {
                var buddyMatchMentor = await _context.BuddyMatch
                    .Where(bmm => bmm.MentorId == id)
                    .ToListAsync();
                buddyMatchMentor.ForEach(bmm => bmm.MentorId = null);
                var buddyMatchMentee = await _context.BuddyMatch
                    .Where(bmm => bmm.MenteeId == id)
                    .ToListAsync();
                buddyMatchMentee.ForEach(bmm => bmm.MenteeId = null);

                _context.Student.Remove(Student);
                await _context.SaveChangesAsync();
            
            }
            return RedirectToPage("./Index");
        }
    }
}
