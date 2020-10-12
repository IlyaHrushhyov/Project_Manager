using IBA_Project1.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IBA_Project1.Model.Repository
{
    public class ProjectRepository : IRepository<Project>
    {
        private Context _context;

        public ProjectRepository(Context context)
        {
            _context = context;
        }


        // Get all
        public async Task<IQueryable<Project>> Get()
        {
            return await Task.FromResult(_context.Projects);
        }

        // Get element by id
        public async Task<Project> Get(int id)
        {

            return await Task.FromResult(_context.Projects.Find(id));
        }

        // Delete element
        public async Task Delete(int id)
        {
            Project project = _context.Projects.Find(id);
            if (project != null)
                await Task.FromResult(_context.Projects.Remove(project));
        }

        // Add new element
        public async Task SaveNew(Project entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("element");
            }

            await Task.FromResult(_context.Projects.Add(entity));

        }

        // Edit element
        public async Task Update(Project project)
        {
            await Task.FromResult(_context.Entry(project).State = EntityState.Modified);
        }

        public IEnumerable<Project> GetWithInclude(params Expression<Func<Project, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetWithInclude(Func<Project, bool> predicate, params Expression<Func<Project, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }


    }
}
