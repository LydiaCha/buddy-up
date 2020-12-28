using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using buddy_up.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace buddy_up.Pages
{
    public class BuddySearchModel : PageModel
    {

        private readonly buddy_up.Data.ApplicationDbContext _context;

        public BuddySearchModel(buddy_up.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Student> Student { get; set; }
        public IList<BuddyMatch> BuddyMatch { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {



            CurrentSort = sortOrder;
            CurrentFilter = searchString;
            IQueryable<Student> studentIQ = from s in _context.Student
                                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                studentIQ = studentIQ.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }

            Student = await studentIQ
    .Include(s => s.Course)
    .Include(s => s.StudentClubMemberships)
        .ThenInclude(s => s.Club)
    .AsNoTracking()
    .ToListAsync();

            BuddyMatch = await _context.BuddyMatch
                .Include(bm => bm.Mentee)
                .Include(bm => bm.Mentor)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
