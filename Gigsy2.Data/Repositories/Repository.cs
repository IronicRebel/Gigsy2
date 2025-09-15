using Gigsy2.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gigsy2.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            // This looks for the entity's primary key
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetByLookupGuidAsync(Guid guid)
        {
            // For ArtistProfile, find by gupLUId
            // For VenueProfile, find by vpLUId (assuming similar naming)
            try {
                return await _dbSet.FirstOrDefaultAsync(e => 
                    (EF.Property<Guid?>(e, "gupLUId") == guid) || 
                    (EF.Property<Guid?>(e, "vpLUId") == guid));
            }
            catch {
                // If properties don't exist, return null
                return null;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}