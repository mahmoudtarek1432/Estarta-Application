using Domain.Entities;

namespace Domain.RepositoryAbstraction
{
    public interface IUserRepository : Base.IRepositoryBase<User, int>
    {
        Task<User?> GetByUsernameAsync(string username);

        Task<User> CreateUserAsync(User user);
    }
}
