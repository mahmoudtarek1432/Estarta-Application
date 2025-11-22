using Domain.Entities;
using Domain.RepositoryAbstraction.Base;

namespace Infrastructure.Repositories
{
    public interface IEmployeeRepository : IRepositoryBase<Employee, int>
    {
        public Task<Employee?> GetEmployeeByNationNumber(string NationalNumber);
    }
}