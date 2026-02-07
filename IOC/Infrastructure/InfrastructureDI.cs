using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Domain.RepositoryAbstraction;

namespace IOC.Infrastructure
{
    public static class InfrastructureDI
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IBranchRepo,BranchRepo>();
            services.AddScoped<ICityRepo,CityRepo>();

        }
    }
}
