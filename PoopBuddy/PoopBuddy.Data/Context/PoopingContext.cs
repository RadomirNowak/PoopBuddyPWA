using Microsoft.EntityFrameworkCore;
using PoopBuddy.Data.Entities;
using PoopBuddy.Shared;

namespace PoopBuddy.Data.Context
{
    public class PoopingContext : DbContext
    {
        private readonly IWebApiConfiguration configuration;

        public PoopingContext(IWebApiConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.ConnectionString);
        }

        public DbSet<PoopingEntity> Poopings { get;set; }
    }
}
