using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        T Add(T entity);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Remove(Guid id);
        int SaveChanges();
        T Update(T entity);
    }
}
