using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace buddy_up.Pages
{
    public class BuddyMatchModel : PageModel
    {
        private readonly ILogger<BuddyMatchModel> _logger;

        public BuddyMatchModel(ILogger<BuddyMatchModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
