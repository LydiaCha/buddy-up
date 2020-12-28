using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using buddy_up.Data;
using buddy_up.Models;
using buddy_up.Models.BuddyUpViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace buddy_up.Pages.Students
{
    public class DropdownsPageModel : PageModel
    {
        public SelectList TableNameSL { get; set; }
        public void PopulateTablesDropDownList(buddy_up.Data.ApplicationDbContext _context, object selectedTable = null)
        {
       
        }

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

        public List<AssignedClubData> AssignedClubDataList;

        public void PopulateAssignedClubData(ApplicationDbContext context,
                                               Student student)
        {
            var allClubs = context.Club;
            var studentClubs = new HashSet<int>(
                student.StudentClubMemberships.Select(scm => scm.ClubID));

            AssignedClubDataList = new List<AssignedClubData>();
            foreach (var club in allClubs)
            {
                AssignedClubDataList.Add(new AssignedClubData
                {
                    ClubID = club.ClubID,
                    Name = club.Name,
                    Assigned = studentClubs.Contains(club.ClubID)
                });
            }
        }
        public void UpdateStudentClubs(ApplicationDbContext context, string[] selectedClubs, Student studentToUpdate)
        {
            if (selectedClubs == null)
            {
                studentToUpdate.StudentClubMemberships = new List<StudentClubMembership>();
                return;
            }
            var selectedClubsHS = new HashSet<string>(selectedClubs);
            var studentClubs = new HashSet<int>(studentToUpdate.StudentClubMemberships.Select(c => c.Club.ClubID));
            foreach(var club in context.Club)
            {
                if (selectedClubsHS.Contains(club.ClubID.ToString()))
                {
                    if (!studentClubs.Contains(club.ClubID))
                    {
                        studentToUpdate.StudentClubMemberships.Add(new StudentClubMembership { StudentID = (int)studentToUpdate.StudentID, ClubID = club.ClubID });
                    }
                }
                else
                {
                    if (studentClubs.Contains(club.ClubID))
                    {
                        StudentClubMembership clubToRemove = studentToUpdate.StudentClubMemberships.SingleOrDefault(s => s.ClubID == club.ClubID);
                        context.Remove(clubToRemove);
                    }
                }
            }
        }
    }
}
