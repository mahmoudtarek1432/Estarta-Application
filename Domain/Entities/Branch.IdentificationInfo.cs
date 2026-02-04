using Domain.Constants;
using Shared_Kernal.Guards;
using Shared_Kernal.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public sealed record BranchIdentificationInfo : IValueObject , IEquatable<BranchIdentificationInfo>
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public BranchStatus Status { get; private set; }

        public BranchIdentificationInfo(string code, string name, BranchStatus status)
        {
            Guard.Against.NotAlphaNumeric(code, $"{nameof(Branch)} {nameof(Code)}");
            Code = code;

            Guard.Against.NullOrWhiteSpace(name, $"{nameof(Branch)} {nameof(Name)}");
            Guard.Against.NotWithinRange(name, 0, 100, $"{nameof(Branch)} {nameof(Name)}");
            Name = name;

            Status = status;
        }
    }
}
