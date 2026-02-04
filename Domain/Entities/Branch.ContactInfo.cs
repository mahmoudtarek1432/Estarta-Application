using Shared_Kernal.Guards;
using Shared_Kernal.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public sealed record BranchContactInfo : IValueObject , IEquatable<BranchContactInfo>
    {
        public string PhoneNumber { get; private set; }
        public string ManagerName { get; private set; }
        public string ManagerContact { get; private set; }

        public BranchContactInfo(string managerName, string managerContact, string phoneNumber)
        {
            Guard.Against.NullOrWhiteSpace(phoneNumber, nameof(phoneNumber));
            Guard.Against.ValidatePhone(phoneNumber, nameof(phoneNumber));
            PhoneNumber = phoneNumber;

            ManagerName = managerName;
            ManagerContact = managerContact;
        }
    }
}
