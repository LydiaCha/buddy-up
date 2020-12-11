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
    public class IndexModel : PageModel
    {
        private readonly buddy_up.Data.ApplicationDbContext _context;

        public IndexModel(buddy_up.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string CourseSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public IList<Student> Student { get;set; }
        public IList<BuddyMatch> BuddyMatch { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
           // CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CourseSort = sortOrder == "Course" ? "course_desc" : "Course";

            IQueryable<Student> studentIQ = from s in _context.Student select s;

            switch (sortOrder)
            {
                case "name_desc":
                    studentIQ = studentIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Course":
                    studentIQ = studentIQ.OrderBy(s => s.CourseId.Name);
                    break;
                case "course_desc":
                    studentIQ = studentIQ.OrderByDescending(s => s.CourseId.Name);
                    break;
                default:
                    studentIQ = studentIQ.OrderBy(s => s.LastName);
                    break;
            }


            Student = await studentIQ
                .Include(s => s.CourseId)
                .Include(s => s.StudentClubMemberships)
                    .ThenInclude(s => s.Club)
                .AsNoTracking()
                .ToListAsync();

            BuddyMatch = await _context.BuddyMatch
                .Include(bm => bm.MenteeId)
                .Include(bm => bm.MentorId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
