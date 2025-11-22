using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Base
{
    public interface IEmployeeService
    {
        Task<EmployeeStatusDto> GetEmployeeStatus(string NationalNumber);
    }
}
