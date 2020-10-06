using IBA_Project1.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBA_Project1.Repository
{
   public interface IRepository<T>
        where T: class, IEntity, new()
    {
        Task<IQueryable<T>> Get();
        Task<T> Get(int id);
      
        Task Delete(int id);
        Task<T> SaveNew(T entity);
        Task Update(T project);
    }
}
