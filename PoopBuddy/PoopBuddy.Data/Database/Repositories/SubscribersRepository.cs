using System;
using System.Collections.Generic;
using System.Text;
using PoopBuddy.Data.Database.Context;
using PoopBuddy.Data.Database.Entities;

namespace PoopBuddy.Data.Database.Repositories
{
    public interface ISubscribersRepository : IRepository<SubscriberEntity>
    {

    }

    public class SubscribersRepository : RepositoryBase<SubscriberEntity>, ISubscribersRepository
    {
        public SubscribersRepository(PoopingContext context) : base(context)
        {
        }
    }
}
