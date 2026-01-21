using Emp.Application.DTOs;
using Emp.Application.Service.Abstraction;
using Emp.Contract.Models;
using Emp.Contract.ReadServices;
using Emp.Domain.RepositoryAbstraction;
using Shared_Kernal.Guards;

namespace Emp.Application.Service
{
    public class EmployeeService : IEmployeeService, IEmployeeReadService
    {
        private IEmployeeRepository _userRepository { get; set; }
        public EmployeeService(IEmployeeRepository userRepository) {
            _userRepository= userRepository;
        }

        public async Task<bool> IsEmployeeFeasible(string NationalNumber)
        {
            var employee = await _userRepository.GetEmployeeByNationNumber(NationalNumber);
            if (employee == null)
                throw new Exception("User not found");
            return employee.IsEmployeeFeasibleFromSalaryCalculation();
        }

        public async Task<EmployeeStatusDto> GetEmployeeStatus(string NationalNumber)
        {
            var employee = await _userRepository.GetEmployeeByNationNumber(NationalNumber);
            if (employee == null)
                throw new NotFoundException("National Number not found");
            if (employee.IsActive == null)
                throw new NotAcceptableException("Employee is not active");
            if (!employee.IsEmployeeFeasibleFromSalaryCalculation())
                throw new UnProcessableEntityException("INSUFFICIENT_DATA");
            var highestSalary = employee.Salaries.Max(e => e.SalaryCalculations());
            var averageSalary = employee.AverageSalary();
            var status = employee.GetEmployeeSalaryStatus();

            return new EmployeeStatusDto
            {
                EmployeeName = employee.UserCivilInfo.FullName,
                NationalNumber = NationalNumber,
                HighestSalary = highestSalary,
                AverageSalary = averageSalary,
                Status = status,
                IsActive = employee.IsActive,
                LastUpdated = DateTime.Now
            };
        }

        async Task<EmployeeStatusReadDto> IEmployeeReadService.GetEmployeeStatus(string NationalNumber)
        {
            var status = await GetEmployeeStatus(NationalNumber);

            return new EmployeeStatusReadDto
            {
                AverageSalary = status.AverageSalary,
                Status = status.Status,
                IsActive = status.IsActive,
                EmployeeName = status.EmployeeName,
                HighestSalary = status.HighestSalary,
                LastUpdated = status.LastUpdated,
                NationalNumber = status.NationalNumber,
            };
        }
    }
}
