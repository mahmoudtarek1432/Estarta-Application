using Domain.Entities.Abstraction;
using Shared_Kernal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryAbstraction.Base
{
    public interface IRepositoryBase<T, R> where T : class, IAggregateRoot
    {

        public Task<IEnumerable<T>> GetAll();

        public Task<T?> GetById<K>(K id);
    }
}
