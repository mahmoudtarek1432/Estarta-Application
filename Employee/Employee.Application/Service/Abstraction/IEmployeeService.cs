using Emp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Application.Service.Abstraction
{
    public interface IEmployeeService
    {
        Task<EmployeeStatusDto> GetEmployeeStatus(string NationalNumber);
    }
}
