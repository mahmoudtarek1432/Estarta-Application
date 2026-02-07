using Application.DTOs.Abstraction;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.CityDtos
{
    public class CityReadDto : IInquiryDto<City, CityReadDto>
    {
        public Guid Id { get; set;  }
        public string CityNameEn { get; set; }
        public string CityNameAr { get; set; }
        public bool IsActive { get; set; }

        public City toEntity()
        {
            return new City(nameEn: CityNameEn, nameAr: CityNameAr, isActive: IsActive);
        }

        public static CityReadDto FromEntity(City entity)
        {
            return new CityReadDto { 
                CityNameAr = entity.NameAr,
                CityNameEn = entity.NameEn,
                Id = entity.Id, 
                IsActive = entity.IsActive
            };
        }
    }
}
