using Domain.Entities;
using Domain.RepositoryAbstraction.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.RepositoryAbstraction
{
    public interface IBranchRepo : IRepository<Branch>
    {
        Task<IEnumerable<Branch>> GetBranchesByMerchantId(string merchantId);
    }
}
