using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface IUserRepository
    {
        public Task<User?> GetUserByNationNumber(string NationalNumber);
    }
}