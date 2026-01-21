
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Emp.Domain.RepositoryAbstraction;
using Emp.Application.Service.Abstraction;
using Emp.Application.Service;
using Emp.Contract.ReadServices;

namespace Emp.IOC.Application
{
    public static class ApplicationDI
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeReadService, EmployeeService>();
            services.AddScoped<IAuthService, AuthService>(provider =>
            {
                var userRepo = provider.GetRequiredService<IUserRepository>();
                return new AuthService(userRepo, configuration);
            });
        }
    }
}
