using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Repositories
{
    public interface IRepository<type> where type : class    /// evrensel temel işlemler için
    {
        DbSet<type> Table { get; } 
    }
}
