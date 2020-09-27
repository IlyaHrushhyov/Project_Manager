using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBA_Project1.Repository
{
    class SQLProjectRepository: IRepository<Project>
    {
        private Context context;

        public SQLProjectRepository()
        {
            this.context = new Context();
        }

        public void Create(Project item)
        {
            context.Projects.Add(item);
        }

        public void Delete(int id)
        {
            Project project = context.Projects.Find(id);
            if (project != null)
                context.Projects.Remove(project);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
            return context.Projects.Find(id);
        }

        public IEnumerable<Project> GetList()
        {
            return context.Projects;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Project item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
