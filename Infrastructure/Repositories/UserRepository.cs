using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User, int>, IUserRepository
    {
        private readonly AppCtx _ctx;

        public UserRepository(AppCtx ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<User?> GetUserByNationNumber(string NationalNumber)
        {
            return await _ctx.Users.Where(e => e.UserCivilInfo.NationalNumber == NationalNumber)
                             .Include(e => e.Salaries)
                             .FirstOrDefaultAsync();
        }
    }
}
