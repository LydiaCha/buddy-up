using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using buddy_up.Models;

namespace buddy_up.Data
{
    public class BuddyUpContext : DbContext
    {
        public BuddyUpContext (DbContextOptions<BuddyUpContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<BuddyMatch> BuddyMatch { get; set; }
        public DbSet<Club> Club { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<ClubType> ClubType { get; set; }

        public DbSet<Course> Course { get; set; }
        public DbSet<Qualification> Qualification { get; set; }

        public DbSet<StudentClubMembership> StudentClubMembership { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<BuddyMatch>().ToTable("BuddyMatch");
            modelBuilder.Entity<Club>().ToTable("Club");
            modelBuilder.Entity<ClubType>().ToTable("ClubType");
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Qualification>().ToTable("Qualification");
            modelBuilder.Entity<StudentClubMembership>().ToTable("StudentClubMembership");
            modelBuilder.Entity<StudentClubMembership>()
                .HasKey(scm => new { scm.StudentID, scm.ClubID });
     
        }
    }
}
