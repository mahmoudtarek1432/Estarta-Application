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

        public User ActivateUser(bool isActive)
        {
            IsActive = isActive;
            return this;
        }
    }
}
