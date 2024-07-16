using Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Repositories
{
    public interface IReadRepository<type> : IRepository<type> where type : Base  //select sorgu işlemleri
    {
        IQueryable<type> GetAll();         /// tüm elemanları getir
        IQueryable<type> GetWhere(Expression<Func<type, bool>> method);
        public int GetAllCount();
        Task<type> GetSingleAsync(Expression<Func<type, bool>> method);  // şartı karşılayan ilk eleman
        Task<type> GetByIdAsync(string id);
    }
}
