using Emp.Domain.Entities;
using Emp.Domain.RepositoryAbstraction.Base;

namespace Emp.Domain.RepositoryAbstraction
{
    public interface IUserRepository : IRepositoryBase<User, int>
    {
        // Add custom user-specific methods here if needed
        Task<User?> GetByUsernameAsync(string username);

        Task<User> CreateUserAsync(User user);
    }
}
