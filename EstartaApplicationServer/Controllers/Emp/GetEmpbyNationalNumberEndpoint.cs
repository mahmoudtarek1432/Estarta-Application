using Microsoft.AspNetCore.Mvc;
using Estarta_Application.Model.Base;
using Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Application.Service.Abstraction;

namespace Estarta_Application.Controllers.Employee
{
    [Route("api/[controller]")]
    public class GetEmpbyNationalNumberEndpoint : Ardalis.ApiEndpoints.EndpointBaseAsync.WithRequest<GetEmpbyNationalNumberEndpointRequest>.WithResult<ResponseBase<EmployeeStatusDto?>>
    {
        public IEmployeeService _empService;

      
        public GetEmpbyNationalNumberEndpoint(IEmployeeService empService)
        {
            _empService = empService;
        }

        [HttpGet]
        public override async Task<ResponseBase<EmployeeStatusDto?>> HandleAsync([FromQuery] GetEmpbyNationalNumberEndpointRequest request, CancellationToken cancellationToken = default)
        {
            var empStatus = await _empService.GetEmployeeByNationalNumber(request.NationalNumber);
            var response = ResponseBase<EmployeeStatusDto>.Success(await _empService.GetEmployeeStatus(request.NationalNumber));

            return response;
        }

    }

    public record class GetEmpbyNationalNumberEndpointRequest() {
       public string NationalNumber { get; set; }
    }
}