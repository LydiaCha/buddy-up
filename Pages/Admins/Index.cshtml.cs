using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using buddy_up.Data;
using buddy_up.Models;

namespace buddy_up.Pages.Admins
{
    public class IndexModel : PageModel
    {
        private readonly buddy_up.Data.BuddyUpContext _context;

        public IndexModel(buddy_up.Data.BuddyUpContext context)
        {
            _context = context;
        }

        public IList<Admin> Admin { get;set; }

        public async Task OnGetAsync()
        {
            Admin = await _context.Admin.ToListAsync();
        }
    }
}
