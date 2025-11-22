using Application.DTOs;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class EmployeeService
    {
        private IUserRepository _userRepository { get; set; }
        public EmployeeService(IUserRepository userRepository) {
            _userRepository= userRepository;
        }

        public bool IsEmployeeFeasible(string NationalNumber)
        {
            var user = _userRepository.GetUserByNationNumber(NationalNumber);
            if (user == null)
                throw new Exception("User not found");
            return user.IsEmployeeFeasibleFromSalaryCalculation();
        }

        public EmployeeStatusDto GetEmployeeStatus(string NationalNumber)
        {
            var user = _userRepository.GetUserByNationNumber(NationalNumber);
            if (user == null)
                throw new Exception("User not found");
            if (!user.IsEmployeeFeasibleFromSalaryCalculation())
                throw new Exception("Employee is not feasible for status calculation");
            var highestSalary = user.Salaries.Max(e => e.SalaryCalculations());
            var averageSalary = user.AverageSalary();
            var status = user.ShouldDetuctTax((int)averageSalary) ? "Taxed" : "Non-Taxed";
            return new EmployeeStatusDto
            {
                EmployeeName = user.UserCivilInfo.FullName,
                NationalNumber = NationalNumber,
                HighestSalary = highestSalary,
                AverageSalary = averageSalary,
                Status = status,
                IsActive = user.IsActive,
                LastUpdated = DateTime.Now
            };
        }

    }
}
