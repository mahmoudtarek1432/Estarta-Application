using Domain.Entities;
using Domain.RepositoryAbstraction.Base;

namespace Domain.RepositoryAbstraction
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);

        Task<User> CreateUserAsync(User user);
    }
}
