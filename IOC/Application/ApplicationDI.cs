using Application.Service;
using Application.Service.Abstraction;
using Domain.RepositoryAbstraction;
using FluentValidation;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Application
{
    public static class ApplicationDI
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<ICityService, CityService>();

        }
    }
}
