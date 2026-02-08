using Application.DTOs;
using Application.DTOs.CityDtos;
using Application.Service.Abstraction;
using Domain.Entities;
using Domain.RepositoryAbstraction;
using Domain.RepositoryAbstraction.Base;
using Domain.Specifications;
using Shared_Kernal.Guards;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace Application.Service
{
    public class CityService : ICityService
    {
        public ICityRepo _CityRepo { get; }

        public CityService(ICityRepo CityRepo )
        {
            _CityRepo = CityRepo;
        }

        public async Task<CityReadDto> GetCity(Guid id)
        {
            var City = await _CityRepo.GetByIdAsync(id);

            if (City == null)
                throw new NotFoundException();

            return CityReadDto.FromEntity(City);
        }


        public async Task<CityReadDto> CreateCity(CityCreateDto model)
        {
            var City = model.toEntity();

            var entity = await _CityRepo.AddAsync(City);

            return CityReadDto.FromEntity(entity);
        }

        public async Task<CityReadDto> UpdateCity(CityUpdateDto model)
        {
            var city = await _CityRepo.GetByIdAsync(model.Id);

            if(city == null)
                throw new NotFoundException();

            city.SetNameEn(model.CityNameEn);
            city.SetNameAr(model.CityNameAr);
            city.SetIsActive(model.IsActive);


            var entity = await _CityRepo.UpdateAsync(city);

            var updatedCity = await _CityRepo.GetByIdAsync(model.Id);

            return CityReadDto.FromEntity(updatedCity);
        }
    }
}
