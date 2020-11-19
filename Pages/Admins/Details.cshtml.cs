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
    public class DetailsModel : PageModel
    {
        private readonly buddy_up.Data.BuddyUpContext _context;

        public DetailsModel(buddy_up.Data.BuddyUpContext context)
        {
            _context = context;
        }

        public Admin Admin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Admin = await _context.Admin.FirstOrDefaultAsync(m => m.AdminId == id);

            if (Admin == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
