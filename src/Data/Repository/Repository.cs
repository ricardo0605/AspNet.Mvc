using Data.Context;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationContext _context;
        public DbSet<T> _dbSet;

        public Repository()
        {
            _context = new ApplicationContext();
            _dbSet = _context.Set<T>();
        }

        public virtual T Add(T entity)
        {
            var objAdd = _dbSet.Add(entity);

            SaveChanges();

            return objAdd;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);

        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable<T>();
        }

        public virtual T GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Remove(Guid id)
        {
            _dbSet.Remove(_dbSet.Find(id));

            SaveChanges();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public virtual T Update(T entity)
        {
            var objEntry = _context.Entry(entity);

            _dbSet.Attach(entity);

            objEntry.State = EntityState.Modified;

            SaveChanges();

            return entity;
        }
    }
}
