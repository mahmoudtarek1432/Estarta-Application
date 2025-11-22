using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
