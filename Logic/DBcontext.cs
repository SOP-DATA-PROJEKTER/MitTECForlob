using Logic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Logic
{
        public class DBcontext : DbContext
        {
            public DBcontext(DbContextOptions<DBcontext> options) : base(options)
            {
            }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MitTECForloeb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply unique constraint on Email
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)  // Specify the property to apply the index
                .IsUnique();  // Ensure it's unique
        }
        public DbSet<AdminKeys> AdminKeys { get; set; }
            public DbSet<Education> Education { get; set; }
            public DbSet<Notes> Notes { get; set; }
            public DbSet<Course> Course { get; set; }
            public DbSet<User> User { get; set; }
            public DbSet<Specs> Specs { get; set; }
            public DbSet<Subj> Subj { get; set; }
            public DbSet<InternshipGoal> InternshipGoal { get; set; }
            public DbSet<InternshipGoalCheck> InternshipGoalCheck { get; set; }
    }
}
