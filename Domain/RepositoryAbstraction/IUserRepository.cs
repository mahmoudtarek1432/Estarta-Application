using Domain.Entities;

namespace Domain.RepositoryAbstraction
{
    public interface IUserRepository : Base.IRepositoryBase<User, int>
    {
        // Add custom user-specific methods here if needed
        Task<User?> GetByUsernameAsync(string username);

        Task<User> CreateUserAsync(User user);
    }
}
