using Ardalis.Specification;
using Shared_Kernal.Interfaces;

namespace Domain.RepositoryAbstraction.Base
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
    {

    }
}
