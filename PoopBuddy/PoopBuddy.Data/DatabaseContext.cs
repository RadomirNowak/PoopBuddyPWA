using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoopBuddy.Data.Entity;

namespace PoopBuddy.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext( DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        public DbSet<PoopingEntity> Poopings { get; set; }
    }
}
