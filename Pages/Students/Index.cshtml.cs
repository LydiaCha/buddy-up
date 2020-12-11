﻿using System;
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

        public IList<Student> Student { get;set; }
        public IList<BuddyMatch> BuddyMatch { get; set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Student
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
