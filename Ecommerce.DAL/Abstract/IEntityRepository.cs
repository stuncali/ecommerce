using Ecommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ecommerce.DAL.Abstract
{
    public interface IEntityRepository<T> where T : IEntity
    {
        T Get(Expression<Func<T, bool>> filter);

        List<T> GetList(Expression<Func<T, bool>> filter = null);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }   
}
