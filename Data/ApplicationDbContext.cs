using System;
using System.Collections.Generic;
using System.Text;
using buddy_up.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace buddy_up.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<BuddyMatch> BuddyMatch { get; set; }
        public DbSet<Club> ClubType { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Qualification> Qualification { get; set; }
        public DbSet<StudentClubMembership> StudentClubMembership { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {    
            modelBuilder.Entity<StudentClubMembership>()
                .HasKey(scm => new { scm.StudentId, scm.ClubId });
            modelBuilder.Entity<StudentClubMembership>()
                .HasOne<Student>(scm => scm.Student)
                .WithMany(c => c.StudentClubMemberships)
                 .HasForeignKey(scm => scm.StudentId);
            modelBuilder.Entity<StudentClubMembership>()
                .HasOne<Club>(scm => scm.Club)
                .WithMany(s => s.StudentClubMemberships)
                .HasForeignKey(scm => scm.ClubId);
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<BuddyMatch>().ToTable("BuddyMatch");
            modelBuilder.Entity<Club>().ToTable("Club");
            modelBuilder.Entity<ClubType>().ToTable("ClubType");
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Qualification>().ToTable("Qualification");
         //   modelBuilder.Entity<StudentClubMembership>().ToTable("StudentClubMembership");
   
        }
    }
}
