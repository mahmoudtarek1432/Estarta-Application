using Emp.Domain.Entities;
using Emp.Domain.RepositoryAbstraction;
using Infrastructure.Context;
using Infrastructure.Repositories.Base;
using Microsoft.Extensions.Caching.Memory;


namespace Infrastructure.Repositories
{
    public class EmployeeRepository : CachingRepositoryBase<Employee, int>, IEmployeeRepository
    {

        public EmployeeRepository(AppCtx ctx, IMemoryCache cacheProvider) : base(ctx, cacheProvider)
        {
            _ctx = ctx;
        }

        public async Task<Employee?> GetEmployeeByNationNumber(string NationalNumber)
        {
            var employeesList = await GetAll(nameof(Employee.Salaries));
            return employeesList.Where(e => e.UserCivilInfo.NationalNumber == NationalNumber)
                             .FirstOrDefault();

        }
    }
}
