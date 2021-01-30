using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class BaseRepository<T> where T : class
    {
        public DbContext Context { get; set; }
        public DbSet<T> Query { get; set; }

        public BaseRepository(AppDbContext context)
        {
            this.Context = context;
            this.Query = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this.Query.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await this.Query.FindAsync(id);
        }

        public async Task Remove(T obj)
        {
            this.Query.Remove(obj);
            await this.Context.SaveChangesAsync();
        }

        public async Task Save(T obj)
        {
            await this.Query.AddAsync(obj);
            await this.Context.SaveChangesAsync();
        }

        public async Task Update(T obj)
        {
            this.Query.Update(obj);
            await this.Context.SaveChangesAsync();
        }
    }
    
}