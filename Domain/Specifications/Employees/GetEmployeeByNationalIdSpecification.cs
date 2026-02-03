using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Specifications.Employees
{
    public class GetEmployeeByNationalIdSpecification : Specification<Employee>
    {
        public GetEmployeeByNationalIdSpecification(string nationalId)
        {
            Query.Where(e => e.Salaries.Count != 0 && e.UserCivilInfo.NationalNumber == nationalId);
            Query.Include(e => e.Salaries);
        }
    }
}
