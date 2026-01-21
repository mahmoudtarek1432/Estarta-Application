using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Contract.Models
{
    public class EmployeeStatusReadDto
    {
        public string EmployeeName { get; set; }
        public string NationalNumber { get; set; }
        public decimal HighestSalary { get; set; }
        public decimal AverageSalary { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
