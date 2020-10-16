using IBA_Project1.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IBA_Project1.Repository
{
    public interface IRepository<T>:IRepositoryBase<T>
         where T : class, IEntity, new()
    {
     
        IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> GetWithInclude(Func<T, bool> predicate,
            params Expression<Func<T, object>>[] includeProperties);

    }
}
