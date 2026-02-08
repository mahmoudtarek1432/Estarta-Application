using Admin_Host.Model.Base;
using Application.DTOs.CityDtos;
using Application.Service.Abstraction;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin_Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _CityService;

        public CityController(ICityService CityService)
        {
            _CityService = CityService;
        }

        [HttpPost]
        public async Task<ResponseBase<CityReadDto>> CreateCity(CityCreateDto model) 
        {
            var resModel = await _CityService.CreateCity(model);
            return ResponseBase<CityReadDto>.Success(resModel);
        }

        [HttpPatch]
        public async Task<ResponseBase<CityReadDto>> UpdateCity(CityUpdateDto model)
        {
            var resModel = await _CityService.UpdateCity(model);
            return ResponseBase<CityReadDto>.Success(resModel);
        }

        [HttpGet("{id}")]
        public async Task<ResponseBase<CityReadDto>> GetCity(Guid id)
        {
            var resModel = await _CityService.GetCity(id);

            return ResponseBase<CityReadDto>.Success(resModel);
        }
    }
}
