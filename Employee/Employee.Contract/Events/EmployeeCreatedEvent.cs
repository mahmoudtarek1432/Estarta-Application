using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Contract.Events
{
    public record EmployeeCreatedEvent(Guid EmployeeId, string EmployeeName);
}
