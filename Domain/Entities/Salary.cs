using Domain.Entities.Abstraction;
using Shared_Kernal.Guards;
using Shared_Kernal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Salary : EntityBase<int>, IAggregateRoot
    {
        public int UserId { get; private set; }
        public decimal Amount { get; private set; }
        public IssueDate issueDate { get; set; }
        public User User { get; set; }

        public Salary SetUserId(int userId)
        {
            UserId = userId;
            return this;
        }

        public Salary SetAmount(decimal amount)
        {
            Guard.Against.CantBeNegative(amount, nameof(this.Amount)));

            Amount = amount;
            return this;
        }
    }
}
