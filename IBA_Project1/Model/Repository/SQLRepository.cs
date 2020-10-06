using IBA_Project1.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace IBA_Project1.Repository
{
    public class SQLRepository<T> : IRepository<T>
        where T : class, IEntity, new()
    {
        private readonly Context _context;

        public SQLRepository(Context context)
        {
            
            _context = context;
        }

        // used to get all entities
        public async Task<IQueryable<T>> Get()
        {
            return await Task.FromResult(_context.Set<T>());
        }

        // used to get only one entity by id
        public async Task<T> Get(int id)
        {
            return await Task.FromResult(Get().Result.FirstOrDefault(x => x.Id == id));
        }
        
        // Update element
        // Here i have some problems with full async implementing
        public async Task <T> SaveNew(T element)
        {
            /*if (element.Id == 0)
                return SaveNew(element).Result;

            var entityElement = Get(element.Id);
            _context.Entry(entityElement).CurrentValues.SetValues(element);
            _context.SaveChanges();
            return element;*/

            if(element == null)
            {
                throw new ArgumentNullException("element");
            }
            _context.Set<T>().Add(element);
            _context.SaveChanges();
            return element;
        }
        public async Task Update(T element)
        {
            /* var entityElement = Get(element.Id);
             _context.Entry(entityElement).CurrentValues.SetValues(element);

             _context.SaveChanges();*/

            var tempElement = _context.Set<T>().Find(element.Id);
            _context.Entry(tempElement).CurrentValues.SetValues(element);
            _context.SaveChanges();
        }
       /* public async Task<T> SaveNew(T element)
        {
            await Task.FromResult(_context.Set<T>().Add(element));
            _context.SaveChanges();
            return element;
        }*/
        public async Task Delete(int id)
        {
            var element = Get(id).Result;
            if (element == null)
                throw new InvalidOperationException("This entity wasnt in the database");

            await Task.FromResult(_context.Set<T>().Remove(element));
            _context.SaveChanges();
        }

      /*  private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

       

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Project item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }*/
    }
}
