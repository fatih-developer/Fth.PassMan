using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Framework.Entities;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);

        List<T> GetList(Expression<Func<T, bool>> filter = null);

        T Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
