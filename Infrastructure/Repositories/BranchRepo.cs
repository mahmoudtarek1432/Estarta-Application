using Domain.Entities;
using Domain.RepositoryAbstraction;
using Domain.RepositoryAbstraction.Base;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class BranchRepo : EFRepositoryBase<Branch>, IBranchRepo
    {
        public BranchRepo(AppCtx ctx) : base(ctx)
        {
            
        }


    }
}
