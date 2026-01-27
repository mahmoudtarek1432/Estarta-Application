using Emp.Domain.Entities;
using Emp.Domain.RepositoryAbstraction;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User, int>, IUserRepository
    {
        private readonly AppCtx _ctx;

        public UserRepository(AppCtx ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _ctx.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();
            return user;
        }
    }
}
