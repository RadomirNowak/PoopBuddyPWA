using PoopBuddy.Data.Context;
using PoopBuddy.Data.Entities;

namespace PoopBuddy.Data.Repositories
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
