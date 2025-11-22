using Shared_Kernal.Interfaces;
using Shared_Kernal.Guards;
using System;

namespace Domain.Entities
{
    public class CivilInfo : IValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string NationalNumber { get; private set; }

        public void SetNationalNumber(string nationalNumber)
        {
            Guard.Against.NullOrWhiteSpace(nationalNumber, nameof(nationalNumber));
            NationalNumber = nationalNumber;
        }
        public string FullName => $"{FirstName} {LastName}";

        public CivilInfo(string firstName, string lastName, string nationalNumber)
        {
            Guard.Against.NullOrWhiteSpace(firstName, nameof(firstName));
            Guard.Against.NullOrWhiteSpace(lastName, nameof(lastName));
            Guard.Against.NullOrWhiteSpace(nationalNumber, nameof(nationalNumber));
            FirstName = firstName;
            LastName = lastName;
            NationalNumber = nationalNumber;
        }
    }
}