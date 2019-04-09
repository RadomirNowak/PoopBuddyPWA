using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using PoopBuddy.Data.Context;
using PoopBuddy.Data.Entities;

namespace PoopBuddy.Data.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

    public abstract class RepositoryBase<T> : IRepository<T> where T : BaseEntity
    {
        private readonly PoopingContext context;
        private readonly DbSet<T> entities;

        protected RepositoryBase(PoopingContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public T GetById(Guid id)
        {
            return entities.Single(e=>e.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.Select(e => e);
        }

        public void Insert([NotNull] T entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));

            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update([NotNull] T entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));

            context.SaveChanges();
        }

        public void Delete([NotNull]T entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));

            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}