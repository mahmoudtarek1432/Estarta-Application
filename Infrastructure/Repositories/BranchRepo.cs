using Domain.Entities;
using Domain.RepositoryAbstraction;
using Domain.RepositoryAbstraction.Base;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Branch>> GetBranchesByMerchantId(string merchantId)
        {
            return await _ctx.Branches.Where(e => e.MerchantId == merchantId)
                                      .Include(e => e.City)
                                      .ToListAsync();
        }
    }
}
