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

namespace Bank.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection service)
        {
            service.AddSingleton<ICustomerService, CustomerService>();
            //service.AddDbContext<BankApiDbContext>(options => options.UseNpgsql("Server = localhost; Port=5432; Database=BankDB; User Id = postgres; Password=admin;"));
            service.AddDbContext<BankApiDbContext>(options =>
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=BankDB; Trusted_Connection=True;"));

        }
    }
}
