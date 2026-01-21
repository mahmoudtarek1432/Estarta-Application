using Emp.Domain.RepositoryAbstraction.Base;
using Microsoft.EntityFrameworkCore;
using Polly;
using Polly.Retry;
using Shared_Kernal.Interfaces;

public abstract class RepositoryBase<T, R> : IRepositoryBase<T, R>
    where T : class, IAggregateRoot
{
    public DbContext _ctx;
    private readonly AsyncRetryPolicy _retryPolicy;

    protected RepositoryBase(DbContext ctx)
    {
        _ctx = ctx;
        // Configure a simple retry policy: 3 retries, exponential backoff
        _retryPolicy = Policy
            .Handle<Exception>() // You can specify more granular exceptions if needed
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    }

    public async Task<IEnumerable<T>> GetAll(params string[]? includes)
    {
        return await _retryPolicy.ExecuteAsync(async () =>
        {
            IQueryable<T> query = _ctx.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.ToListAsync();
        });
    }

    public async Task<T?> GetById<K>(K id)
    {
        return await _retryPolicy.ExecuteAsync(async () =>
        {
            return await _ctx.Set<T>().FindAsync(id);
        });
    }
}