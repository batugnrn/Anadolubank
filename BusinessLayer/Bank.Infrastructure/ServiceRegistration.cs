using Bank.Application.Abstractions;
using Bank.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastactureServices(this IServiceCollection service)
        {
            service.AddScoped<IToken, Token>();
        }
    }
}
