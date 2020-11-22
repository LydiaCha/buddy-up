using buddy_up.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buddy_up.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BuddyUpContext context, IServiceProvider services)
        {

            context.Database.EnsureCreated();

            if (context.Student.Any())
            {
                return;   
            }

            var countries = new Country[]
                {
                new Country{Name="United Kingdom"}
                };
            foreach (Country c in countries)
            {
                context.Country.Add(c);
            }
            context.SaveChanges();

            var qualifications = new Qualification[]
    {
                new Qualification{Name="LLB"}
    };
            foreach (Qualification q in qualifications)
            {
                context.Qualification.Add(q);
            }
            context.SaveChanges();

            var courses = new Course[]
                {
                new Course{Name="Law", QualificationId = qualifications.Single(q => q.Name == "LLB"), Duration="3 years", Description="UK Law" }
                };
            foreach (Course c in courses)
            {
                context.Course.Add(c);
            }
            context.SaveChanges();

            var clubTypes = new ClubType[]
                {
                new ClubType{Name="Extreme Sports", Description="Physically demanding and dangerous" }
                };
            foreach (ClubType ct in clubTypes)
            {
                context.ClubType.Add(ct);
            }
            context.SaveChanges();

            var clubs = new Club[]
    {
                new Club{Name="Snowboarding", ClubTypeId=clubTypes.Single(ct => ct.Name == "Extreme Sports") }
    };
            foreach (Club c in clubs)
            {
                context.Club.Add(c);
            }
            context.SaveChanges();

            var students = new Student[]
            {
            new Student{ FirstName="Carson", LastName="Alexander", Address="24 Happy Road, London, W1 0HU", CountryId=countries.Single(c => c.Name == "United Kingdom"),
                CourseId = courses.Single(c => c.Name == "Law"), YearOfStudy=2, EmailAddress="Carson@hotmail.com", DateOfBirth=DateTime.Parse("2001-09-01"), TelephoneNumber="07895186899"}
            };
            foreach (Student s in students)
            {
                context.Student.Add(s);
            }
            context.SaveChanges();

            var studentClubMemberships = new StudentClubMembership[]
{
                new StudentClubMembership{StudentID=students.Single(s => (s.FirstName == "Carson" && s.LastName == "Alexander")).StudentID, 
                    ClubID=clubs.Single(c => c.Name == "Snowboarding").ClubID }
};
            foreach (StudentClubMembership scm in studentClubMemberships)
            {
                context.StudentClubMembership.Add(scm);
            }
            context.SaveChanges();     
            


        }


    }
}
