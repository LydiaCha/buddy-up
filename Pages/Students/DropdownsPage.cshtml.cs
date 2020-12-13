using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace buddy_up.Pages.Students
{
    public class DropdownsPageModel : PageModel
    {
        public SelectList CountryNameSL { get; set; }

        public void PopulateCoutryDropDownList(buddy_up.Data.ApplicationDbContext _context,
            object selectedCountry = null)
        {
            var countryQuery = from c in _context.Country
                                   orderby c.Name // Sort by name.
                                   select c;

            CountryNameSL = new SelectList(countryQuery.AsNoTracking(),
                        "CountryID", "Name", selectedCountry);
        }

        public SelectList CourseNameSL { get; set; }

        public void PopulateCourseDropDownList(buddy_up.Data.ApplicationDbContext _context,
            object selectedCourse = null)
        {
            var courseQuery = from c in _context.Course
                              orderby c.Name // Sort by name.
                              select c;

            CourseNameSL = new SelectList(courseQuery.AsNoTracking(),
                        "CourseID", "Name", selectedCourse);
        }
    }
}
