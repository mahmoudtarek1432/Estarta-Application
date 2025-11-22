using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IOC.Infrastructure
{
    public static class InfrastructureDI
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
