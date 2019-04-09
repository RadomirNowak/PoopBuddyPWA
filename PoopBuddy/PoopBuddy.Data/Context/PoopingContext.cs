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

        public PoopingContext(DbContextOptions<PoopingContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(optionsBuilder.IsConfigured == false) // checking if db was not already configured for InMemory tests
                optionsBuilder.UseSqlServer(configuration.ConnectionString);
        }

        public DbSet<PoopingEntity> Poopings { get;set; }
    }
}
