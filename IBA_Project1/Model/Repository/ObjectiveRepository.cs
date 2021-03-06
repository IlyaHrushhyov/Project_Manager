﻿using IBA_Project1.Model.Entities;
using IBA_Project1.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IBA_Project1.Model.Repository
{
    public class ObjectiveRepository : IRepository<Objective>
    {
        private Context _context;

        public ObjectiveRepository(Context context)
        {
            _context = context;
        }


        // Get all
        public async Task<IQueryable<Objective>> Get()
        {
            return (IQueryable<Objective>)await Task.FromResult(_context.Objectives.ToList());
        }

        // Get element by id
        public async Task<Objective> Get(int id)
        {

            return await Task.FromResult(_context.Objectives.Find(id));
        }

        // Delete element
        public async Task Delete(int id)
        {
            Objective objective = _context.Objectives.Find(id);
            if (objective != null)
                await Task.FromResult(_context.Objectives.Remove(objective));
        }

        // Add new element
        public async Task SaveNew(Objective entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("element");
            }

            await Task.FromResult(_context.Entry(entity).State = EntityState.Added);
            await Task.FromResult(_context.SaveChanges());
            await Task.FromResult(_context.Entry(entity).State = EntityState.Detached);

        }

        // Edit element
        public async Task Update(Objective objective)
        {
            // not async
            //_context.Set<Objective>().AddOrUpdate(objective);

            // async
            Objective existing = await _context.Objectives.FindAsync(objective.Id);
            existing.Name = objective.Name;
            await _context.SaveChangesAsync();
        }

        #region MethodsToGetObjectives
        public IEnumerable<Objective> GetWithInclude(params Expression<Func<Objective, object>>[] includeProperties)
        {
            IQueryable<Objective> query = _context.Set<Objective>().AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        private IQueryable<Objective> Include(params Expression<Func<Objective, object>>[] includeProperties)
        {
            IQueryable<Objective> query = _context.Set<Objective>().AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public IEnumerable<Objective> GetWithInclude(Func<Objective, bool> predicate, params Expression<Func<Objective, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }
        #endregion

    }
}
