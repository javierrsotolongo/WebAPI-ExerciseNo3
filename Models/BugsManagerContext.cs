using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugsManager.Models
{
    public class BugsManagerContext : DbContext
    {
        public BugsManagerContext(DbContextOptions<BugsManagerContext> options) :
            base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Bug> Bugs { get; set; }

    }
}
