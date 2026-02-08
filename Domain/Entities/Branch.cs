using Domain.Entities.Base;
using Shared_Kernal.Guards;
using Shared_Kernal.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Branch : EntityBase<string>, IAggregateRoot, ISoftDeleteable
    {
        public string MerchantId { get; private set; }
        public BranchIdentificationInfo BranchIDInfo { get; set; }
        public BranchAddressInfo BranchAddressInfo { get; set; }
        public BranchContactInfo BranchContactInfo { get; set; }
        public BranchServiceRestrictions BranchServiceRestrictions { get; set; }
        
        public Guid CityId { get; set; }
        public City City { get; set; }
        public bool IsDeleted { get; set; }

        public Branch() { }

        public Branch (BranchContactInfo branchContact, BranchServiceRestrictions branchSerivces, BranchAddressInfo branchAddressInfo, BranchIdentificationInfo branchIDInfo, string merchantId)
        {
            BranchContactInfo = branchContact;
            BranchServiceRestrictions = branchSerivces;
            BranchAddressInfo = branchAddressInfo;
            BranchIDInfo = branchIDInfo;
            SetMerchantId(merchantId);
        }

        public void SetMerchantId(string merchantId)
        {
            //branches shouldn't change merchants
            if (MerchantId != null)
                throw new BusinessLogicException("The branch is already assigned to a merchant");

            Guard.Against.NullOrWhiteSpace(merchantId, nameof(merchantId));
            MerchantId = merchantId;
        }

        public void SetId(string id)
        {
            Guard.Against.NullOrWhiteSpace(id, nameof(id));
            Id = id;
        }

        public void SetCityId(Guid cityid)
        {
            CityId = cityid;
        }
    }
}
