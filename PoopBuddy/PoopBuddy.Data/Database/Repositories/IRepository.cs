using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using PoopBuddy.Data.Database.Context;
using PoopBuddy.Data.Database.Entities;

namespace PoopBuddy.Data.Database.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        [NotNull] T GetById(Guid id);
        [CanBeNull] T GetByIdOrDefault(Guid id);
        IEnumerable<T> GetAll();
        Guid Add([NotNull] T entity);
        void Update([NotNull] T entity);
        void Delete([NotNull] T entity);
        void Delete(Guid id);
        [NotNull]T GetSingle([NotNull] Expression<Func<T, bool>> expression);
        [CanBeNull]T GetSingleOrDefault([NotNull] Expression<Func<T, bool>> expression);
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

        public T GetByIdOrDefault(Guid id)
        {
            return entities.SingleOrDefault(e=>e.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.Select(e => e);
        }

        public Guid Add(T entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));

            entities.Add(entity);
            context.SaveChanges();

            return entity.Id;
        }

        public void Update(T entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));

            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));

            entities.Remove(entity);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            Delete(entity);
        }

        public T GetSingle(Expression<Func<T,bool>> expression)
        {
            if (expression == null) 
                throw new ArgumentNullException(nameof(expression));

            return entities.Single(expression);
        }

        public T GetSingleOrDefault(Expression<Func<T, bool>> expression)
        {
            if (expression == null) 
                throw new ArgumentNullException(nameof(expression));

            return entities.SingleOrDefault(expression);
        }
    }
}