using Shared_Kernal.Guards;
using Shared_Kernal.Interfaces;

namespace Domain.Entities
{
    public sealed record BranchContactInfo : IValueObject , IEquatable<BranchContactInfo>
    {
        public string PhoneNumber { get; private set; }
        public string ManagerName { get; private set; }
        public string ManagerContact { get; private set; }

        public BranchContactInfo(string managerName, string managerContact, string phoneNumber)
        {
            SetPhoneNumber(phoneNumber);

            SetManagerName(managerName);

            SetManagerContact(managerContact);
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            Guard.Against.NullOrWhiteSpace(phoneNumber, nameof(phoneNumber));
            Guard.Against.ValidatePhone(phoneNumber, nameof(phoneNumber));
            PhoneNumber = phoneNumber;
        }

        public void SetManagerName(string managerName)
        {
            ManagerName = managerName;
        }

        public void SetManagerContact(string managerContact)
        {
            ManagerContact = managerContact;
        }
    }
}
