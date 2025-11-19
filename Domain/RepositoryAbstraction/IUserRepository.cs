using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface IUserRepository
    {
        public User? GetUserByNationNumber(string NationalNumber);
    }
}