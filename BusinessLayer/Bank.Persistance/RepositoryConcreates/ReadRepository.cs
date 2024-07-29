using Bank.Application.Repositories;
using Bank.Domain.Entities;
using Bank.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Persistance.RepositoryConcreates
{
    public class ReadRepository<type> : IReadRepository<type> where type : Base
    {
        private readonly BankApiDbContext bankApiDbContext;
        public ReadRepository(BankApiDbContext context)
        {
            bankApiDbContext = context;
        }
        public DbSet<type> Table => bankApiDbContext.Set<type>();
        public IQueryable<type> GetAll()
        => Table;
        public int GetAllCount()
        {
            return Table.Count();
        }
        public async Task<type> GetByIdAsync(string id)
        => await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        public async Task<type> GetSingleAsync(Expression<Func<type, bool>> method)
        => await Table.FirstOrDefaultAsync(method);
        public IQueryable<type> GetWhere(Expression<Func<type, bool>> method)
        => Table.Where(method);
    }
}
