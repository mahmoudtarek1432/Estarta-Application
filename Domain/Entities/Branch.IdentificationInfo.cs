using Domain.Constants;
using Shared_Kernal.Guards;
using Shared_Kernal.Interfaces;
using System.Xml.Linq;

namespace Domain.Entities
{
    public sealed record BranchIdentificationInfo : IValueObject , IEquatable<BranchIdentificationInfo>
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public BranchStatus Status { get; private set; }

        public BranchIdentificationInfo(string code, string name, BranchStatus status)
        {
            setCode(code);

            setName(name);

            SetStatus(status);
        }

        public void setName(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, $"{nameof(Branch)} {nameof(Name)}");
            Guard.Against.NotWithinRange(name, 0, 100, $"{nameof(Branch)} {nameof(Name)}");
            Name = name.Trim();
        }

        public void setCode(string code)
        {
            Guard.Against.NotAlphaNumeric(code, $"{nameof(Branch)} {nameof(Code)}");
            Code = code.Trim();
        }

        public void SetStatus(BranchStatus status)
        {
            Status = status;
        }
    }
}
