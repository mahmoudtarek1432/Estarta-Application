using Microsoft.AspNetCore.Mvc;
using Estarta_Application.Model.Base;
using Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Application.Service.Abstraction;

namespace Estarta_Application.Controllers.Employee
{
    [Route("api/[controller]")]
    [Authorize]
    public class GetEmpStatusEndpoint : Ardalis.ApiEndpoints.EndpointBaseAsync.WithRequest<GetEmpStatusEndpointRequest>.WithResult<ResponseBase<EmployeeStatusDto?>>
    {
        public IEmployeeService _empService;

      
        public GetEmpStatusEndpoint(IEmployeeService empService)
        {
            _empService = empService;
        }

        [HttpGet]
        public override async Task<ResponseBase<EmployeeStatusDto?>> HandleAsync([FromQuery]GetEmpStatusEndpointRequest request, CancellationToken cancellationToken = default)
        {
            var empStatus = await _empService.GetEmployeeStatus(request.NationalNumber);
            var response = ResponseBase<EmployeeStatusDto>.Success(await _empService.GetEmployeeStatus(request.NationalNumber));

            return response;
        }

    }

    public record class GetEmpStatusEndpointRequest() {
       public string NationalNumber { get; set; }
    }
}