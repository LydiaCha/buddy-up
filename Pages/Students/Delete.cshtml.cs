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

        public async Task<IActionResult> OnGetAsync(int? id)
        {
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
                Student = await _context.Student
                        .Include(s => s.Country)
                        .Include(s => s.Course)
                        .Include(s => s.StudentClubMemberships)
                            .ThenInclude(s => s.Club)
                        .SingleAsync(s => s.StudentID == id);

                BuddyMatch = await _context.BuddyMatch
    .Include(bm => bm.MenteeId)
    .Include(bm => bm.MentorId)
    .AsNoTracking()
    .ToListAsync();

                _context.Student.Remove(Student);
                await _context.SaveChangesAsync();
            
            }
            return RedirectToPage("./Index");
        }
    }
}
