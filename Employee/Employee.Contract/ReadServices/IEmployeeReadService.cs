using Emp.Contract.Models;


namespace Emp.Contract.ReadServices
{
    public interface IEmployeeReadService
    {
        public Task<EmployeeStatusReadDto> GetEmployeeStatus(string NationalNumber);
    }
}
