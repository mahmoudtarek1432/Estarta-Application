using Application.DTOs.BranchDtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service.Abstraction
{
    public interface IBranchService
    {
        Task<BranchReadDto> CreateBranch(BranchCreateDto model);
        Task<BranchReadDto> GetBranch(Guid id);
        Task<IEnumerable<BranchReadDto>> GetMerchantBranches(Guid merchantId);
        Task<BranchReadDto> UpdateBranch(BranchUpdateDto model);
    }
}
