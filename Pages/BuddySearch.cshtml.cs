using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using buddy_up.Models;
using buddy_up.Pages.Students;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace buddy_up.Pages
{
    public class BuddySearchModel : DropdownsPageModel
    {

        private readonly buddy_up.Data.ApplicationDbContext _context;

        public BuddySearchModel(buddy_up.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public string CurrentOtherFilter { get; set; }

        public IList<Student> Student { get; set; }
        public IList<BuddyMatch> BuddyMatch { get; set; }
        public string NameSort { get; set; }
        public string CourseSort { get; set; }

        public async Task OnGetAsync(string searchString, string sortOrder, string otherFilter = null)
        {
            CurrentOtherFilter = otherFilter;

            CurrentSort = sortOrder;

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CourseSort = sortOrder == "Course" ? "course_desc" : "Course";
            
            CurrentFilter = searchString;
            IQueryable<Student> studentIQ = from s in _context.Student
                                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                switch (otherFilter)
                {
                    case "name":
                        studentIQ = studentIQ.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
                        break;
                    case "course":
                        studentIQ = studentIQ.Where(s => s.Course.Name.Contains(searchString));
                        break;
                    case "club":
                        studentIQ = studentIQ.Where(s => s.StudentClubMemberships.Any(c => c.Club.Name.Contains(searchString)));
                        break;
                    default:
                        studentIQ = studentIQ = studentIQ.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString) || s.Course.Name.Contains(searchString)
                                       || s.StudentClubMemberships.Any(c => c.Club.Name.Contains(searchString)));
                        break;
                }
            } 

            switch (sortOrder)
            {
                case "name_desc":
                    studentIQ = studentIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Course":
                    studentIQ = studentIQ.OrderBy(s => s.Course.Name);
                    break;
                case "course_desc":
                    studentIQ = studentIQ.OrderByDescending(s => s.Course.Name);
                    break;
                default:
                    studentIQ = studentIQ.OrderBy(s => s.LastName);
                    break;
            
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
