using Application.DTOs.Abstraction;
using Domain.Entities;


namespace Application.DTOs.CityDtos
{
    public class CityUpdateDto : IPersistanceDto<City>
    {
        public Guid Id { get; set; }
        public string CityNameEn { get; set; }
        public string CityNameAr { get; set; }
        public bool IsActive { get; set; }

        public City toEntity()
        {
            return new City(nameEn: CityNameEn, nameAr: CityNameAr, isActive: IsActive);
        }
    }
}
