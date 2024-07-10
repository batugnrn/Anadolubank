using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Repositories
{
    public interface IWriteRepository<type> : IRepository<type> where type : class   //insert, update, delete işlemleri
    {
        Task<bool> AddAsync(type model);
        Task<bool> AddAsync(List<type> models);
        Task<bool> Remove(type model);
        Task<bool> Remove(string id);
        Task<bool> UpdateAsync(string id);
    }
}
