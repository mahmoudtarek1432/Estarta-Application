using Emp.Domain.Entities;
using Emp.Domain.RepositoryAbstraction.Base;

namespace Emp.Domain.RepositoryAbstraction
{
    public interface IEmployeeRepository : IRepositoryBase<Employee, int>
    {
        public Task<Employee?> GetEmployeeByNationNumber(string NationalNumber);
    }
}