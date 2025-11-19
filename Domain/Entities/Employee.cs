using Domain.Entities.Abstraction;
using Shared_Kernal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : EntityBase<int>, IAggregateRoot
    {
        public CivilInfo UserCivilInfo { get; set; }
        public AccountInfo UserAccountInfo { get; set; }
        public bool IsActive { get; private set; } = false;
    }

    public class Salaries : EntityBase<int>, IAggregateRoot
    {

        public int UserId { get; private set; }
        public decimal Salary { get; private set; }
        public IssueDate issueDate { get; set; }
        public User User { get; set; }
    }
}
