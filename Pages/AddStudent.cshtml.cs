﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace buddy_up.Pages
{
    public class AddStudentModel : PageModel
    {
        private readonly ILogger<AddStudentModel> _logger;

        public AddStudentModel(ILogger<AddStudentModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
