using Domain.Entities.Abstraction;
using Shared_Kernal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryAbstraction
{
    public interface IRepositoryBase<T, R> where T : EntityBase<T>, IAggregateRoot
    {

        public Task<IEnumerable<T>> GetAll();

        public Task<T?> GetById<K>(K id);
    }
}
