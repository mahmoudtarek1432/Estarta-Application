
using Ardalis.Specification.EntityFrameworkCore;
using Domain.RepositoryAbstraction.Base;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Polly;
using Polly.Retry;
using Shared_Kernal.Interfaces;

public abstract class EFRepositoryBase<T> : RepositoryBase<T> , IRepository<T>
    where T : class, IAggregateRoot
{
    public AppCtx _ctx;
    private readonly AsyncRetryPolicy _retryPolicy;

    protected EFRepositoryBase(AppCtx ctx):base(ctx)
    {
        _ctx = ctx;
        // Configure a simple retry policy: 3 retries, exponential backoff
        _retryPolicy = Policy
            .Handle<Exception>() // You can specify more granular exceptions if needed
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    }
}