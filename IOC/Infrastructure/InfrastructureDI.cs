using Microsoft.Extensions.DependencyInjection;
using Emp.Domain.RepositoryAbstraction;
using Infrastructure.Repositories;

namespace IOC.Infrastructure
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
