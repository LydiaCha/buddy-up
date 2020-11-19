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

        public DbSet<buddy_up.Models.Student> Student { get; set; }

        public DbSet<buddy_up.Models.Admin> Admin { get; set; }
    }
}
