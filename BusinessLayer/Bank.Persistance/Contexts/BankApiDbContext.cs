using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Bank.Domain.Entities.Identity;

namespace Bank.Persistance.Contexts
{
    public class BankApiDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public BankApiDbContext(DbContextOptions options) : base(options) { }



        public DbSet<Customers> customers { get; set; }
        public DbSet<Login> logins { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Transaction> transactions { get; set; }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{

        //    var datas = ChangeTracker.Entries<Base>();
        //    foreach (var item in datas) {
        //        var result = item.State switch
        //        {
        //            EntityState.Added => item.Entity.
        //            default:
        //        };
        //    }
        //    return base.SaveChangesAsync(cancellationToken);
        //}


    }
}
