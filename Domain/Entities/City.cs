using Domain.Entities.Base;
using Shared_Kernal.Guards;
using Shared_Kernal.Interfaces;

namespace Domain.Entities
{
    public class City : EntityBase<Guid>, IAggregateRoot
    {
        public string NameEn { get; private set; }
        public string NameAr { get; private set; }
        public bool IsActive { get; private set; }
        public ICollection<Branch> Branches { get; set; }
        public City() { }

        public City(string nameEn, string nameAr, bool isActive)
        {
            SetNameEn(nameEn);
            SetNameAr(nameAr);
            SetIsActive(isActive);
        }

        public void SetNameEn(string nameEn)
        {
            Guard.Against.NullOrWhiteSpace(nameEn, nameof(NameEn));
            Guard.Against.NotAlphaNumeric(nameEn, nameof(NameEn));
            Guard.Against.NotWithinRange(nameEn, 1, 50, nameof(NameEn));
            NameEn = nameEn;
        }

        public void SetNameAr(string nameAr)
        {
            Guard.Against.NullOrWhiteSpace(nameAr, nameof(NameAr));
            Guard.Against.NotAlphaNumeric(nameAr, nameof(NameAr));
            Guard.Against.NotWithinRange(nameAr, 1, 50, nameof(NameAr));

            NameAr = nameAr;
        }

        public void SetIsActive(bool isActive)
        {
            IsActive = isActive;
        }
    }
}
