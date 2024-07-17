using Bank.Application.Repositories;
using Bank.Domain.Entities;
using Bank.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Persistance.RepositoryConcreates
{
    public class WriteRepository<type> : IWriteRepository<type> where type : Base
    {
        private readonly BankApiDbContext bankApiDbContext;
        public WriteRepository(BankApiDbContext context)
        {
            bankApiDbContext = context;
        }
        public DbSet<type> Table => bankApiDbContext.Set<type>();

        public async Task<bool> AddAsync(type model)
        {
            EntityEntry<type> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<type> models)
        {
            await Table.AddRangeAsync(models);
            return true;
        }

        public bool Remove(type model)
        {
            EntityEntry<type> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
           type model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id)); 
            
           return Remove(model);
        }
        public bool RemoveRange(List<type> models)
        {
            Table.RemoveRange(models);
            return true;
        }

        public bool UpdateAsync(type model)
        {
            EntityEntry<type> entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
        public async Task<int> SaveAsync()
        => await bankApiDbContext.SaveChangesAsync();
    }
}
