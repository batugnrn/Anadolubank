using Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Repositories
{
    public interface IWriteRepository<type> : IRepository<type> where type : Base   //insert, update, delete işlemleri
    {
        Task<bool> AddAsync(type model);
        Task<bool> AddRangeAsync(List<type> models);
        bool Remove(type model);
        Task<bool> RemoveAsync(string id);
        bool RemoveRange(List<type> models);
        bool UpdateAsync(type model);
        Task<int> SaveAsync();
    }
}
