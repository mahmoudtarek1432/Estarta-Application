using Application.DTOs;
using Application.Service.Base;
using Infrastructure.Repositories;
using Shared_Kernal.Guards;

namespace Application.Service
{
    public class EmployeeService : IEmployeeService
    {
        private IUserRepository _userRepository { get; set; }
        public EmployeeService(IUserRepository userRepository) {
            _userRepository= userRepository;
        }

        public async Task<bool> IsEmployeeFeasible(string NationalNumber)
        {
            var user = await _userRepository.GetUserByNationNumber(NationalNumber);
            if (user == null)
                throw new Exception("User not found");
            return user.IsEmployeeFeasibleFromSalaryCalculation();
        }

        public async Task<EmployeeStatusDto> GetEmployeeStatus(string NationalNumber)
        {
            var user = await _userRepository.GetUserByNationNumber(NationalNumber);
            if (user == null)
                throw new NotFoundException("National Number not found");
            if (user.IsActive == null)
                throw new NotAcceptableException("User is not active");
            if (!user.IsEmployeeFeasibleFromSalaryCalculation())
                throw new UnProcessableEntityException("INSUFFICIENT_DATA");
            var highestSalary = user.Salaries.Max(e => e.SalaryCalculations());
            var averageSalary = user.AverageSalary();
            var status = user.GetUserSalaryStatus();

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
