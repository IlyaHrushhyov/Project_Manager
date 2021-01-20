using IBA_Project1.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBA_Project1.Model.Repository
{
    public class UserRepository:IRepositoryBase<User>
    {
        private Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }
        // Get all
        public async Task<IQueryable<User>> Get()
        {
            return await Task.FromResult(_context.Users);
        }

        // Get element by id
        public async Task<User> Get(int id)
        {

            return await Task.FromResult(_context.Users.Find(id));
        }

        // Delete element
        public async Task Delete(int id)
        {
            User user = _context.Users.Find(id);
            if (user != null)
                await Task.FromResult(_context.Users.Remove(user));
        }

        // Add new element
        public async Task SaveNew(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("element");
            }


            //await Task.FromResult(_context.Projects.Add(entity));

            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
        }

        // Edit element
        public async Task Update(User user)
        {
            await Task.FromResult(_context.Entry(user).State = EntityState.Modified);
        }

    }
}
