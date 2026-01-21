using Emp.Domain.RepositoryAbstraction.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Shared_Kernal.Interfaces;


namespace Emp.Infrastructure.Repositories.Base
{
    public class CachingRepositoryBase<T, R> : RepositoryBase<T,R>, IRepositoryBase<T, R>
        where T : class, IAggregateRoot
    {
        private readonly DbContext _ctx;
        private readonly IMemoryCache _cache;
        private readonly MemoryCacheEntryOptions _cacheOptions;

        public CachingRepositoryBase(DbContext ctx, IMemoryCache cache) : base(ctx)
        {
            _ctx = ctx;
            _cache = cache;
            _cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            };
        }

        public async Task<IEnumerable<T>> GetAll(string[]? includes)
        {
            var cacheKey = $"{typeof(T).FullName}_all";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<T> items))
            {
                items = await GetAll(includes);
                _cache.Set(cacheKey, items, _cacheOptions);
            }
            return items;
        }

        public async Task<T?> GetById<K>(K id)
        {
            var cacheKey = $"{typeof(T).FullName}_id_{id}";
            if (!_cache.TryGetValue(cacheKey, out T item))
            {
                item = await GetById(id);
                if (item != null)
                    _cache.Set(cacheKey, item, _cacheOptions);
            }
            return item;
        }
    }
}
