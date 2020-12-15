using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using buddy_up.Data;
using buddy_up.Models;
using buddy_up.Models.BuddyUpViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace buddy_up.Pages.Students
{
    public class StudentClubsPageModel : PageModel
    {
/*        public List<AssignedClubData> AssignedClubDataList;

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
        }*/

/*        public void UpdateInstructorCourses(SchoolContext context,
            string[] selectedCourses, Instructor instructorToUpdate)
        {
            if (selectedCourses == null)
            {
                instructorToUpdate.CourseAssignments = new List<CourseAssignment>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var instructorCourses = new HashSet<int>
                (instructorToUpdate.CourseAssignments.Select(c => c.Course.CourseID));
            foreach (var course in context.Courses)
            {
                if (selectedCoursesHS.Contains(course.CourseID.ToString()))
                {
                    if (!instructorCourses.Contains(course.CourseID))
                    {
                        instructorToUpdate.CourseAssignments.Add(
                            new CourseAssignment
                            {
                                InstructorID = instructorToUpdate.ID,
                                CourseID = course.CourseID
                            });
                    }
                }
                else
                {
                    if (instructorCourses.Contains(course.CourseID))
                    {
                        CourseAssignment courseToRemove
                            = instructorToUpdate
                                .CourseAssignments
                                .SingleOrDefault(i => i.CourseID == course.CourseID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }*/
    }
}
