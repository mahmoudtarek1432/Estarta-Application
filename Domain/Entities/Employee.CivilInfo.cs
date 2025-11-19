using Shared_Kernal.Interfaces;
using Shared_Kernal.Guards;
using System;

namespace Domain.Entities
{
    public class CivilInfo : IValueObject
    {
        public string NationalNumber { get; private set; }

        public void SetNationalNumber(string nationalNumber)
        {
            Guard.Against.NullOrWhiteSpace(nationalNumber, nameof(nationalNumber));
            NationalNumber = nationalNumber;
        }
    }
}