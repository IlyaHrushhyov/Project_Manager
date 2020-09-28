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
            //this.context = new Context();
            _context = context;
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>();
        }

        public T Get(int id)
        {
            return Get().FirstOrDefault(x => x.Id == id);
        }
        
        public T Save(T element)
        {
            if (element.Id == 0)
                return SaveNew(element);

            var entityElement = Get(element.Id);
            _context.Entry(entityElement).CurrentValues.SetValues(element);
            _context.SaveChanges();
            return element;
        }
        public T SaveNew(T element)
        {
            _context.Set<T>().Add(element);
            _context.SaveChanges();
            return element;
        }
        public void Delete(int id)
        {
            var element = Get(id);
            if (element == null)
                throw new InvalidOperationException("This entity wasnt in the database");

            _context.Set<T>().Remove(element);
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
