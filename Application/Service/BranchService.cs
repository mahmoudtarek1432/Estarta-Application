using Application.DTOs.BranchDtos;
using Application.Service.Abstraction;
using Domain.Entities;
using Domain.RepositoryAbstraction;
using Domain.RepositoryAbstraction.Base;
using Domain.Specifications;
using Shared_Kernal.Guards;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
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

        public async Task<BranchReadDto> GetBranch(string id)
        {
            var branch = await _branchRepo.GetByIdAsync(id);

            if (branch == null)
                throw new NotFoundException();

            return BranchReadDto.FromEntity(branch);
        }

        public async Task<IEnumerable<BranchReadDto>> GetMerchantBranches(string merchantId)
        {
            var branch = await _branchRepo.GetBranchesByMerchantId(merchantId);

            return branch.Select(BranchReadDto.FromEntity);
        }


        public async Task<BranchReadDto> CreateBranch(BranchCreateDto model)
        {
            var branch = model.toEntity();

            var nameExists = await _branchRepo.AnyAsync(new BranchNameLookupSpecification(model.BranchName));
            if (nameExists)
                throw new BusinessLogicException("The Branch Name Is Not Unique");

            var entity = await _branchRepo.AddAsync(branch);

            return BranchReadDto.FromEntity(entity);
        }

        public async Task<BranchReadDto> UpdateBranch(BranchUpdateDto model)
        {
            var branch = await _branchRepo.GetByIdAsync(model.BranchId);

            if(branch == null)
                throw new NotFoundException();

            var nameExists = await _branchRepo.AnyAsync(new BranchNameLookupSpecification(model.BranchName, model.BranchId));

            if (nameExists)
                throw new BusinessLogicException("The Branch Name Should be Unique");

            branch.BranchIDInfo = new BranchIdentificationInfo(code: model.BranchCode, 
                                                               name: model.BranchName,
                                                               status: model.Status);

            branch.BranchContactInfo = new BranchContactInfo(managerName: model.ManagerName, 
                                                             managerContact: model.ManagerContact, 
                                                             phoneNumber: model.PhoneNumber);

            branch.BranchServiceRestrictions = new BranchServiceRestrictions(disableRefund: model.DisableRefund, 
                                                                             disablePartialRefund: model.DisablePartialRefund, 
                                                                             disableCollection: model.DisableCollection, 
                                                                             disableVouchers: model.DisableVouchers);

            branch.BranchAddressInfo = new BranchAddressInfo(address: model.Address, district: model.District);

            branch.SetCityId(model.CityId);

            var entity = await _branchRepo.UpdateAsync(branch);

            var updatedBranch = await _branchRepo.GetByIdAsync(model.BranchId);

            return BranchReadDto.FromEntity(updatedBranch);
        }
    }
}
