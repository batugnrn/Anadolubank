using Bank.Application.Abstractions;
using Bank.Persistance.Concreates;
using Bank.Persistance.Contexts;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Application.Repositories.CustomerRepository;
using Bank.Persistance.RepositoryConcreates.CustomerConcreates;
using Bank.Application.Repositories.LoginRepository;
using Bank.Persistance.RepositoryConcreates.LoginConcreates;
using Bank.Application.Repositories.AccountRepository;
using Bank.Persistance.RepositoryConcreates.AccountConcreates;
using Bank.Domain.Entities.Identity;
using System.Collections.Immutable;
using Bank.Application.Repositories.TransactionRepository;
using Bank.Persistance.RepositoryConcreates.TransactionConcreates;

namespace Bank.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection service)
        {
            service.AddSingleton<ICustomerService, CustomerService>();

            //service.AddDbContext<BankApiDbContext>(options => options.UseNpgsql("Server = localhost; Port=5432; Database=BankDB; User Id = postgres; Password=admin;"));
            service.AddDbContext<BankApiDbContext>(options =>
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=BankDB6; Trusted_Connection=True;"),ServiceLifetime.Singleton);
            service.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BankApiDbContext>();

            service.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            service.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            service.AddScoped<ILoginReadRepository, LoginReadRepository>();
            service.AddScoped<ILoginWriteRepository, LoginWriteRepository>();
            service.AddScoped<IAccountReadRepository, AccountReadRepository>();
            service.AddScoped<IAccountWriteRepository, AccountWriteRepository>();
            service.AddScoped<ITransactionReadRepository, TransactionReadRepository>();
            service.AddScoped<ITransactionWriteRepository, TransactionWriteRepository>();
            




        }
    }
}
