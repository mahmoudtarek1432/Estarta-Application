using Domain.Entities.Abstraction;
using Domain.RepositoryAbstraction.Base;
using Microsoft.EntityFrameworkCore;
using Shared_Kernal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.RepositoryBase
{
    public abstract class RepositoryBase<T,R>: IRepositoryBase<T,R>
    where T : class, IAggregateRoot
    {
        public DbContext _ctx;

        protected RepositoryBase(DbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<T>> GetAll() {
            return await _ctx.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById<K>(K id)
        {
            return await _ctx.Set<T>().FindAsync(id);
        }
    }
}
