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

            public DbSet<AdminKeys> AdminKeys { get; set; }
            public DbSet<Education> Education { get; set; }
            public DbSet<Notes> Notes { get; set; }
            public DbSet<Progress> Progress { get; set; }
            public DbSet<User> User { get; set; }
            public DbSet<Specs> Specs { get; set; }
            public DbSet<Subj> Subj { get; set; }
    }
}
