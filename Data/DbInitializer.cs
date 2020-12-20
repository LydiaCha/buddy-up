using buddy_up.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buddy_up.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context, IServiceProvider services)
        {

            context.Database.EnsureCreated();

            if (context.Student.Any())
            {
                return;
            }

            var countries = new Country[]
                {
                new Country{Name="United Kingdom"},
                new Country{Name="Poland"},
                new Country{Name="Greece"},
                new Country{Name="United States"},
                new Country{Name="France"},
                new Country{Name="Italy"},
                new Country{Name="Netherlands"},
                new Country{Name="Belgium"}
                };
            foreach (Country c in countries)
            {
                context.Country.Add(c);
            }
            context.SaveChanges();

            var qualifications = new Qualification[]
    {
                new Qualification{Name="LLB"},
                new Qualification{Name="BA"},
                new Qualification{Name="BSC"}
    };
            foreach (Qualification q in qualifications)
            {
                context.Qualification.Add(q);
            }
            context.SaveChanges();

            var courses = new Course[]
                {
                new Course{Name="Law", QualificationId = qualifications.Single(q => q.Name == "LLB"), Duration="3 years", Description="UK Law" },
                new Course{Name="Digital and Technology Solutions", QualificationId = qualifications.Single(q => q.Name == "BSC"), Duration="3 years", Description="IT and software engineering." },
                new Course{Name="Psychology", QualificationId = qualifications.Single(q => q.Name == "BA"), Duration="3 years", Description="Deep dive into the human mind" },
                new Course{Name="Mathematics", QualificationId = qualifications.Single(q => q.Name == "BSC"), Duration="3 years", Description="Study of numbers" },
                new Course{Name="Film", QualificationId = qualifications.Single(q => q.Name == "BA"), Duration="3 years", Description="All about the film industry, including production" },
                new Course{Name="Medicine", QualificationId = qualifications.Single(q => q.Name == "BSC"), Duration="5 years", Description="Healing the human body" },
                new Course{Name="Archeology", QualificationId = qualifications.Single(q => q.Name == "BA"), Duration="4 years", Description="Digging for treasure" }
                };
            foreach (Course c in courses)
            {
                context.Course.Add(c);
            }
            context.SaveChanges();

            var clubTypes = new ClubType[]
                {
                new ClubType{Name="Extreme Sports", Description="Physically demanding and dangerous" },
                new ClubType{Name="Crafts", Description="Variety of crafts to do at home" },
                new ClubType{Name="Music", Description="Music appreciation society" },
                new ClubType{Name="Sports", Description="Physical activity" },
                new ClubType{Name="Intellectual", Description="Mentally demanding" },
                new ClubType{Name="Media", Description="Various media related clubs" }
                };
            foreach (ClubType ct in clubTypes)
            {
                context.ClubType.Add(ct);
            }
            context.SaveChanges();

            var clubs = new Club[]
    {
                new Club{Name="Snowboarding", ClubTypeId=clubTypes.Single(ct => ct.Name == "Extreme Sports") },
                new Club{Name="Knitting", ClubTypeId=clubTypes.Single(ct => ct.Name == "Crafts") },
                new Club{Name="Basketball", ClubTypeId=clubTypes.Single(ct => ct.Name == "Sports") },
                new Club{Name="Football", ClubTypeId=clubTypes.Single(ct => ct.Name == "Sports") },
                new Club{Name="Harry Potter", ClubTypeId=clubTypes.Single(ct => ct.Name == "Media") },
                new Club{Name="Chess", ClubTypeId=clubTypes.Single(ct => ct.Name == "Intellectual") },
                new Club{Name="Running", ClubTypeId=clubTypes.Single(ct => ct.Name == "Sports") }
    };
            foreach (Club c in clubs)
            {
                context.Club.Add(c);
            }
            context.SaveChanges();

            var students = new Student[]
            {
            new Student{ FirstName="Carson", LastName="Alexander", Address="24 Happy Road, London, W1 0HU", CountryId=countries.Single(c => c.Name == "United Kingdom").CountryID,
                CourseId = courses.Single(c => c.Name == "Law").CourseID, YearOfStudy=2, EmailAddress="Carson@hotmail.com", DateOfBirth=DateTime.Parse("2001-09-01"), TelephoneNumber="07895186899"},
            new Student{ FirstName="Tom", LastName="Jones", Address="10 Swimming Lane, Cardif, C14 6LD", CountryId=countries.Single(c => c.Name == "United Kingdom").CountryID,
                CourseId = courses.Single(c => c.Name == "Digital and Technology Solutions").CourseID, YearOfStudy=1, EmailAddress="TomJones@hotmail.com", DateOfBirth=DateTime.Parse("1960-09-10"), TelephoneNumber="07995186779"},
            new Student{ FirstName="Deborah", LastName="Morgan", Address="1501 Holywood Plaza, Miami, 15-129", CountryId=countries.Single(c => c.Name == "United States").CountryID,
                CourseId = courses.Single(c => c.Name == "Psychology").CourseID, YearOfStudy=1, EmailAddress="DMorgan@miami.com", DateOfBirth=DateTime.Parse("1980-05-14"), TelephoneNumber="00117895154899"},
            };
            foreach (Student s in students)
            {
                context.Student.Add(s);
            }
            context.SaveChanges();

            var studentClubMemberships = new StudentClubMembership[]
            {
                new StudentClubMembership{StudentID=(int)students.Single(s => (s.FirstName == "Carson" && s.LastName == "Alexander")).StudentID,
                    ClubID=clubs.Single(c => c.Name == "Snowboarding").ClubID },
                new StudentClubMembership{StudentID=(int)students.Single(s => (s.FirstName == "Tom" && s.LastName == "Jones")).StudentID,
                    ClubID=clubs.Single(c => c.Name == "Knitting").ClubID },
                new StudentClubMembership{StudentID=(int)students.Single(s => (s.FirstName == "Deborah" && s.LastName == "Morgan")).StudentID,
                    ClubID=clubs.Single(c => c.Name == "Running").ClubID }
            };
            foreach (StudentClubMembership scm in studentClubMemberships)
            {
                context.StudentClubMembership.Add(scm);
            }
            /*       context.SaveChanges();*/

            var admins = new Admin[]
                       {
            new Admin{ FirstName="Lydia", LastName="C", Address="15 Athens Place, Larissa, 23-098", CountryId=countries.SingleOrDefault(c => c.Name == "Greece").CountryID,
                EmailAddress="LydiaC@hotmail.com", DateOfBirth=DateTime.Parse("1997-04-23"), TelephoneNumber="07896176899"},
            new Admin{ FirstName="Pheobe", LastName="Waller-Bridge", Address="11 Priory Lane, London, W1C 4GH", CountryId=countries.SingleOrDefault(c => c.Name == "United Kingdom").CountryID,
                EmailAddress="PWB@hotmail.com", DateOfBirth=DateTime.Parse("1986-01-30"), TelephoneNumber="07967486779"},
            new Admin{ FirstName="Harry", LastName="Morgan", Address="101 Cross Avenue, Miami, 11-189", CountryId=countries.SingleOrDefault(c => c.Name == "United States").CountryID,
                EmailAddress="HMorgan@miami.com", DateOfBirth=DateTime.Parse("1960-04-15"), TelephoneNumber="00117895154811"}
                       };
            foreach (Admin a in admins)
            {
                context.Admin.Add(a);
            }
            context.SaveChanges();

            var buddyMatch = new BuddyMatch[]
           {
            new BuddyMatch{ Mentor=students.Single(s => s.FirstName == "Deborah" && s.LastName == "Morgan"), Mentee=students.Single(s => s.FirstName == "Tom" && s.LastName == "Jones") }
           };
            foreach (BuddyMatch bm in buddyMatch)
            {
                context.BuddyMatch.Add(bm);
            }
            context.SaveChanges();

            var aspNetUsers = new IdentityUser[]
            {
                new IdentityUser{ Id="1", UserName="Test1@test.com", NormalizedUserName="TEST1@TEST.COM", Email="Test1@test.com", NormalizedEmail="TEST1@TEST.COM", EmailConfirmed=true,
                    PasswordHash="AQAAAAEAACcQAAAAEFG93Mm+WTLaWguVMVtVOFreRdBNR0muaiHWRHRHe5pF2zgk75dzNDjfFvMafTtBlA==", PhoneNumberConfirmed=false, TwoFactorEnabled=false, LockoutEnabled=false, AccessFailedCount=0 },
                new IdentityUser{ Id="2", UserName="Test2@test.com", NormalizedUserName="TEST2@TEST.COM", Email="Test2@test.com", NormalizedEmail="TEST2@TEST.COM", EmailConfirmed=true,
                    PasswordHash="AQAAAAEAACcQAAAAEFG93Mm+WTLaWguVMVtVOFreRdBNR0muaiHWRHRHe5pF2zgk75dzNDjfFvMafTtBlA==", PhoneNumberConfirmed=false, TwoFactorEnabled=false, LockoutEnabled=false, AccessFailedCount=0 },
                new IdentityUser{ Id="3", UserName="Test3@test.com", NormalizedUserName="TEST3@TEST.COM", Email="Test3@test.com", NormalizedEmail="TEST3@TEST.COM", EmailConfirmed=true,
                    PasswordHash="AQAAAAEAACcQAAAAEFG93Mm+WTLaWguVMVtVOFreRdBNR0muaiHWRHRHe5pF2zgk75dzNDjfFvMafTtBlA==", PhoneNumberConfirmed=false, TwoFactorEnabled=false, LockoutEnabled=false, AccessFailedCount=0 },
            };

            foreach (IdentityUser i in aspNetUsers)
            {
                context.AspNetUsers.Add(i);
            }


            context.SaveChanges();
        }


    }
}
