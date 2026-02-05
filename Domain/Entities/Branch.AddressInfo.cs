using Shared_Kernal.Guards;
using Shared_Kernal.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public sealed record BranchAddressInfo : IValueObject , IEquatable<BranchAddressInfo>
    {
        public string Address { get; private set; }
        public string District { get; private set; }

        public BranchAddressInfo(string address, string district)
        {
            SetAddress(address);

            SetDistrict(district);
        }

        public void SetAddress(string address)
        {
            Guard.Against.NullOrWhiteSpace(address, $"{nameof(Branch)} {nameof(Address)}");
            Address = address;
        }

        public void SetDistrict(string district)
        {
            Guard.Against.NullOrWhiteSpace(district, $"{nameof(Branch)} {nameof(District)}");
            District = district;
        }
    }
}
