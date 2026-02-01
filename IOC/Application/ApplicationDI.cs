using Application.Service;
using Application.Service.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.RepositoryAbstraction;

namespace IOC.Application
{
    public static class ApplicationDI
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IAuthService, AuthService>(provider =>
            {
                var userRepo = provider.GetRequiredService<IUserRepository>();
                return new AuthService(userRepo, configuration);
            });
        }
    }
}
