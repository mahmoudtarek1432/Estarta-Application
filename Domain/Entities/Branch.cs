using Domain.Entities.Base;
using Shared_Kernal.Guards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Branch : EntityBase<Guid>
    {
        public BranchIdentificationInfo BranchIDInfo { get; set; }
        public BranchAddressInfo BranchAddressInfo { get; set; }
        public BranchContactInfo BranchContactInfo { get; set; }
        public BranchServiceRestrictions BranchServiceRestrictions { get; set; }
        public Guid MerchantId { get; private set; }

        public Branch() { }

        public Branch (BranchIdentificationInfo branchIDInfo, Guid merchantId)
        {
            BranchIDInfo = branchIDInfo;
            SetMerchantId(merchantId);

        }

        public void SetMerchantId(Guid merchantId)
        {
            Guard.Against.NullOrEmpty(merchantId, nameof(merchantId));
            MerchantId = merchantId;
        }
    }
}
