using Microsoft.Extensions.DependencyInjection;
using Emp.Infrastructure.Repositories;
using Emp.Domain.RepositoryAbstraction;

namespace Emp.IOC.Infrastructure
{
    public static class InfrastructureDI
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
