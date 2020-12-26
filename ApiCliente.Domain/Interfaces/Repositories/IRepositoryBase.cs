using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApiCliente.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
        IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate);
    }
}
