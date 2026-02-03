using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Abstraction
{
    public interface IEmployeeService
    {
        Task<Employee?> GetEmployeeByNationalNumber(string nationalNumber);
        Task<EmployeeStatusDto> GetEmployeeStatus(string NationalNumber);
    }
}
