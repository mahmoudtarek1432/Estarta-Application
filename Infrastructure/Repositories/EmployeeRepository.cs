using Domain.Entities;
using Domain.RepositoryAbstraction;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : EFRepositoryBase<Employee>, IEmployeeRepository
    {
        private readonly AppCtx _ctx;
        public EmployeeRepository(AppCtx ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<Employee?> GetEmployeeByNationNumber(string NationalNumber)
        {
            var employeesList = _ctx.Employees.Include(e => e.Salaries);

            return employeesList.Where(e => e.UserCivilInfo.NationalNumber == NationalNumber)
                             .FirstOrDefault();

        }
    }
}
