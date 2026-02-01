using Shared_Kernal.Interfaces;

namespace Domain.RepositoryAbstraction.Base
{
    public interface IRepositoryBase<T, R> where T : class, IAggregateRoot
    {

        public Task<IEnumerable<T>> GetAll(params string[] includes);

        public Task<T?> GetById<K>(K id);
    }
}
