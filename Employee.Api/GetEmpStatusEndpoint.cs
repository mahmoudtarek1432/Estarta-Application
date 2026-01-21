using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
using Emp.Application.Service.Abstraction;
using Shared_Kernal.Model.Base;
using Emp.Application.DTOs;

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