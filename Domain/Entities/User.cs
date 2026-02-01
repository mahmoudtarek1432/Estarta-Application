using Domain.Entities.Base;
using Shared_Kernal.Guards;
using Shared_Kernal.Interfaces;
using Shared_Kernal.Security;

namespace Domain.Entities
{
    public class User : EntityBase<int>, IAggregateRoot
    {

        public string Username { get; private set; }
        public string Password { get; private set; }

        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public User() { }

        public User(string username, string password)
        {
            Username = ValidateUsername(username);
            Password = SecurityUtilities.HashPassword(ValidatePassword(password));
        }

        private string ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new BusinessLogicException("Username cannot be empty.");
            if (username.Length < 3)
                throw new BusinessLogicException("Username must be at least 3 characters.");
            return username;
        }

        private string ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new BusinessLogicException("Password cannot be empty.");
            if (password.Length < 6)
                throw new BusinessLogicException("Password must be at least 6 characters.");
            return password;
        }
    }
}
