using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service.Abstraction
{
    public interface IBranchService
    {
        Task<Branch> CreateBranch(BranchCreateDto model);
        Task<BranchReadDto> GetBranch(string id);
    }
}
