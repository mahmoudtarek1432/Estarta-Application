using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ModelConfigurations
{
    public partial class DBConfigurationBuilder
    {
        private ModelBuilder _builder;
        public DBConfigurationBuilder(ModelBuilder builder)
        {
            _builder = builder;
        }
    }
}
