using Domain.Entities;
using Infrastructure.Configuration;
using Infrastructure.ModelConfigurations;
using Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class AppCtx : DbContext
    {
        public DbSet<Branch> Branches { get; set; }
        public DbSet<City> Cities { get; set; }

        public AppCtx(DbContextOptions<AppCtx> opt) : base(opt)
        {
        }

        public async Task SeedDatabaseAsync()
        {
            await DatabaseSeeder.SeedAsync(this);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            ModelBuilderConfigurations.SoftdeleteFilter(modelBuilder);

           var modelConfigurations = new DBConfigurationBuilder(modelBuilder);

            modelConfigurations.BranchModelConfig()
                               .CityModelConfig();

            base.OnModelCreating(modelBuilder);
        }
    }
}
