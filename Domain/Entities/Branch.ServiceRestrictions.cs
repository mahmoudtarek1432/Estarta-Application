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
            SetDisableRefund(disableRefund);

            SetDisablePartialRefund(disablePartialRefund);

            SetDisableCollection(disableCollection);

            SetDisableVouchers(disableVouchers);
        }

        public void SetDisableRefund(bool disableRefund)
        {
            DisableRefund = disableRefund;
        }

        public void SetDisablePartialRefund(bool disablePartialRefund)
        {
            DisablePartialRefund = disablePartialRefund;

            DisabledRefundDisablesPartialRefund(DisableRefund, DisablePartialRefund);
        }

        public void SetDisableCollection(bool disableCollection)
        {
            DisableCollection = disableCollection;
        }

        public void SetDisableVouchers(bool disableVouchers)
        {
            DisableVouchers = disableVouchers;
        }

        private void DisabledRefundDisablesPartialRefund(bool disableRefund, bool disablePartialRefund)
        {
            if (disableRefund is true && disablePartialRefund is false)
                DisablePartialRefund = false;
        }
    }
}
