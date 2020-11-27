using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace buddy_up.Pages
{
    public class BuddySearchModel : PageModel
    {
        private readonly ILogger<BuddySearchModel> _logger;

        public BuddySearchModel(ILogger<BuddySearchModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
