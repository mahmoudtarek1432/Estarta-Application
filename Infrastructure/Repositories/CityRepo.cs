using Domain.Entities;
using Domain.RepositoryAbstraction;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class CityRepo : EFRepositoryBase<Branch>, ICityRepo
    {
        public CityRepo(AppCtx ctx) : base(ctx)
        {

        }
    }
}
