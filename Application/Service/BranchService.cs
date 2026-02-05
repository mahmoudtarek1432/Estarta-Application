using Application.DTOs;
using Application.Service.Abstraction;
using Domain.Entities;
using Domain.RepositoryAbstraction;
using Domain.RepositoryAbstraction.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service
{
    public class BranchService : IBranchService
    {
        public IBranchRepo _branchRepo { get; }

        public BranchService(IBranchRepo branchRepo )
        {
            _branchRepo = branchRepo;
        }


        public async Task<Branch> CreateBranch(BranchCreateDto model)
        {
            var branch = model.toEntity();

            branch.SetId("BR01");

            var entity = await _branchRepo.AddAsync(branch);

            return entity;
        }

        public async Task<BranchReadDto> GetBranch(string id)
        {
            var branch = await _branchRepo.GetByIdAsync<string>(id);

            return BranchReadDto.fromEntity(branch);
        }
    }
}
