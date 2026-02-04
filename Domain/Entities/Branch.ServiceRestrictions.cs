using Shared_Kernal.Guards;
using Shared_Kernal.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public sealed record BranchServiceRestrictions : IValueObject , IEquatable<BranchServiceRestrictions>
    {
        public bool DisableRefund { get; private set; } = false;
        public bool DisablePartialRefund { get; private set; } = false;
        public bool DisableCollection { get; private set; } = false;
        public bool DisableVouchers { get; private set; } = false;

        public BranchServiceRestrictions(bool disableRefund, bool disablePartialRefund, bool disableCollection, bool disableVouchers)
        {
            DisablePartialRefund = disablePartialRefund;

            DisableRefund = disableRefund;

            if (disableRefund is true && disablePartialRefund is false)
                DisablePartialRefund = false;

            DisableCollection = disableCollection;
            DisableVouchers = disableVouchers;
        }
    }
}
