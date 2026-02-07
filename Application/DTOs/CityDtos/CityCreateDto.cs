using Application.DTOs.Abstraction;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.CityDtos
{
    public class CityCreateDto : IPersistanceDto<City>
    {
        public string CityNameEn { get; set; }
        public string CityNameAr { get; set; }
        public bool IsActive { get; set; }

        public City toEntity()
        {
            return new City(nameEn: CityNameEn, nameAr: CityNameAr, isActive: IsActive);
        }

    }
}
