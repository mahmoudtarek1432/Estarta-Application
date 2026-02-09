using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ModelConfigurations
{
    public partial class DBConfigurationBuilder
    {
        public DBConfigurationBuilder CityModelConfig()
        {

            _builder.Entity<City>().HasKey(x => x.Id);

            _builder.Entity<City>().Property(x => x.NameAr).HasMaxLength(50);
            _builder.Entity<City>().Property(x => x.NameEn).HasMaxLength(50);

            return this;
        }
    }
}
