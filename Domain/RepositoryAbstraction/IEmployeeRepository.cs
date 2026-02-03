using Domain.Entities;
using Domain.RepositoryAbstraction.Base;

namespace Domain.RepositoryAbstraction
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        public Task<Employee?> GetEmployeeByNationNumber(string NationalNumber);
    }
}