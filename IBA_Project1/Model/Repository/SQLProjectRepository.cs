using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBA_Project1.Repository
{
   /* public class SQLProjectRepository<T>: IRepository<T>
        where T : class
    {
        private readonly Context _context;

        public SQLProjectRepository(Context context)
        {
            //this.context = new Context();
            _context = context;
        }

        public void Create(T item)
        {
            _context.Projects.Add(item);
        }

        public void Delete(int id)
        {
            var element = _context.Projects.Find(id);
            if (element != null)
                _context.Projects.Remove(element);
            else
                throw new InvalidOperationException("This entity wasnt in the database");
          
        }

        private bool disposed = false;

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

        public Project GetElement(int id)
        {
            return _context.Projects.Find(id);
        }

        public IEnumerable<Project> GetList()
        {
            return _context.Projects;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Project item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }*/
}
