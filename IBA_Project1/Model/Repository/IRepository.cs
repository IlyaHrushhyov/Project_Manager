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
        IQueryable<T> Get();
        T Get(int id);
      
        void Delete(int id);
        T Save(T entity);
    }
}
