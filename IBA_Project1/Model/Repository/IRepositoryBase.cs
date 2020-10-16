using IBA_Project1.Model.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace IBA_Project1.Repository
{
    public interface IRepositoryBase<T>
         where T : class, IEntity, new()
    {
        Task<IQueryable<T>> Get();
        Task<T> Get(int id);

        Task Delete(int id);

        Task SaveNew(T entity);
        Task Update(T project);
       

    }
}
