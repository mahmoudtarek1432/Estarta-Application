using Application.DTOs.Abstraction;
using Domain.Constants;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.BranchDtos
{
    public class BranchCreateDto : IPersistanceDto<Branch>
    {
        public string BranchId { get; set; }
        public string MerchantId { get;  set; }
        public string Address { get;  set; }
        public string District { get;  set; }
        public string PhoneNumber { get;  set; }
        public string? ManagerName { get;  set; }
        public string? ManagerContact { get;  set; }
        public string BranchCode { get;  set; }
        public string BranchName { get;  set; }
        public bool DisableRefund { get;  set; }
        public bool DisablePartialRefund { get;  set; }
        public bool DisableCollection { get;  set; }
        public bool DisableVouchers { get;  set; }
        public BranchStatus Status { get;  set; }

        public Branch toEntity()
        {
            var identification = new BranchIdentificationInfo(code: BranchCode, name: BranchName, status: Status);
            var contact = new BranchContactInfo(managerName: ManagerName, managerContact: ManagerContact, phoneNumber: PhoneNumber);
            var serviceRestrictions = new BranchServiceRestrictions(disableRefund: DisableRefund, disablePartialRefund: DisablePartialRefund, disableCollection: DisableCollection, disableVouchers: DisableVouchers);
            var addressInfo = new BranchAddressInfo(address: Address, district: District);

            var branch =  new Branch(branchContact: contact,
                               branchAddressInfo: addressInfo,
                               branchSerivces: serviceRestrictions,
                               branchIDInfo: identification,
                               merchantId: MerchantId);
            branch.SetId(BranchId);

            return branch;
        }

        public static BranchCreateDto fromEntity(Branch branch)
        {
            return new BranchCreateDto
            {
                BranchId = branch.Id,
                MerchantId = branch.MerchantId,
                Address = branch.BranchAddressInfo.Address,
                District = branch.BranchAddressInfo.District,
                BranchCode = branch.BranchIDInfo.Code,
                BranchName = branch.BranchIDInfo.Name,
                PhoneNumber = branch.BranchContactInfo.PhoneNumber,
                ManagerName = branch.BranchContactInfo.ManagerName,
                ManagerContact = branch.BranchContactInfo.ManagerContact,
                Status = branch.BranchIDInfo.Status,
                DisableCollection = branch.BranchServiceRestrictions.DisableCollection,
                DisableRefund = branch.BranchServiceRestrictions.DisableRefund,
                DisablePartialRefund = branch.BranchServiceRestrictions.DisablePartialRefund,
                DisableVouchers = branch.BranchServiceRestrictions.DisableVouchers
            };
        }
    }
}
