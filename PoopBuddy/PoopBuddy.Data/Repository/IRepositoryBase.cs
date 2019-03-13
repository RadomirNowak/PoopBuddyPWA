using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoopBuddy.Data.Entity;

namespace PoopBuddy.Data.Repository
{
    public interface IPoopingRepository
    {
        IEnumerable<PoopingEntity> GetAll();
        void Add(PoopingEntity entityToAdd);
    }

    public class PoopingRepository : IPoopingRepository
    {
        private DatabaseContext dbContext;

        public PoopingRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public IEnumerable<PoopingEntity> GetAll()
        {
            return dbContext.Poopings.ToList();
        }

        public void Add(PoopingEntity entityToAdd)
        {
            dbContext.Poopings.Add(entityToAdd);
            dbContext.SaveChanges();
        }
    }
}
