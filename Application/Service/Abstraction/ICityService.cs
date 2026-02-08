using Application.DTOs;
using Application.DTOs.CityDtos;
using Domain.Entities;
using Domain.RepositoryAbstraction;
using Shared_Kernal.Guards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service.Abstraction
{
    public interface ICityService
    {
        public Task<CityReadDto> GetCity(Guid id);

        public Task<CityReadDto> CreateCity(CityCreateDto model);

        public Task<CityReadDto> UpdateCity(CityUpdateDto model);
    }
}
