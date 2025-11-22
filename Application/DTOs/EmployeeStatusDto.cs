using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class EmployeeStatusDto
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
