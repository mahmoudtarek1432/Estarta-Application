using Shared_Kernal.Guards;
using Shared_Kernal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AccountInfo : IValueObject
    {
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        public AccountInfo SetUserName(string userName)
        {
            Guard.Against.NullOrWhiteSpace(userName, nameof(UserName));

            UserName = userName;

            return this;
        }

        public AccountInfo SetEmail(string email)
        {
            Guard.Against.ValidateEmail(email, nameof(email));
            Email = email;

            return this;
        }

        public AccountInfo SetPhoneNumber(string phoneNumber)
        {
            Guard.Against.ValidatePhone(phoneNumber, nameof(PhoneNumber));
            PhoneNumber = phoneNumber;
            return this;
        }
    }
}
