using Domain.Entities;
using Domain.RepositoryAbstraction.Base;

namespace Domain.RepositoryAbstraction
{
    public interface IEmployeeRepository : IRepositoryBase<Employee, int>
    {
        public Task<Employee?> GetEmployeeByNationNumber(string NationalNumber);
    }
}