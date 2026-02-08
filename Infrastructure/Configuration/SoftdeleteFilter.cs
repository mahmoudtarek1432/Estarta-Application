using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.Configuration
{
    internal class ModelBuilderConfigurations
    {
        internal static void SoftdeleteFilter(ModelBuilder modelBuilder)
        {

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (!typeof(ISoftDeleteable).IsAssignableFrom(entityType.ClrType))
                    continue;

                var param = Expression.Parameter(entityType.ClrType, "e");
                var propIsDeleted = Expression.Property(param, nameof(ISoftDeleteable.IsDeleted));

                // Expression: !e.IsDeleted
                var notDeleted = Expression.Not(propIsDeleted);

                var lambda = Expression.Lambda(notDeleted, param);
                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }

        }
    }
}
