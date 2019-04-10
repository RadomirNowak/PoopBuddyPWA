using PoopBuddy.Data.Database.Context;
using PoopBuddy.Data.Database.Entities;

namespace PoopBuddy.Data.Database.Repositories
{
    public interface IPoopingRepository : IRepository<PoopingEntity>
    {
        
    }

    public class PoopingRepository : RepositoryBase<PoopingEntity>, IPoopingRepository
    {
        public PoopingRepository(PoopingContext context) : base(context)
        {
        }
    }
}
