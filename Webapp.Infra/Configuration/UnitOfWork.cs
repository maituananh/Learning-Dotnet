using Application.Configurations;
using Infra.Configuration;
using Infra.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infra.Configurations;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork, IDisposable
{
    private bool disposedValue;

    private IDbContextTransaction? _transaction;

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        audit();
        await context.SaveChangesAsync(cancellationToken);
        await _transaction!.CommitAsync(cancellationToken);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                context.Dispose();
            }

            disposedValue = true;
        }
    }

    void IDisposable.Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    private void audit()
    {
        var entries = context.ChangeTracker.Entries()
            .Where(e => e.Entity is AuditEntity && (e.State == Microsoft.EntityFrameworkCore.EntityState.Added || e.State == Microsoft.EntityFrameworkCore.EntityState.Modified));

        foreach (var entry in entries)
        {
            var entity = (AuditEntity)entry.Entity;
            var now = DateTime.UtcNow;

            if (entry.State == Microsoft.EntityFrameworkCore.EntityState.Added)
            {
                entity.CreatedAt = now;
            }
            entity.UpdatedAt = now;
        }
    }

    public async Task BeginTransactionAsync(CancellationToken cancellationToken)
    {
        _transaction = await context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task RollbackAsync(CancellationToken cancellationToken)
    {
        await _transaction!.RollbackAsync(cancellationToken);
    }
}
