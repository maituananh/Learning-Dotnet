using Application.Configurations;
using Infra.Configuration;
using Infra.Entities;

namespace Infra.Configurations;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context = context;

    private bool disposedValue;

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        audit();
        await _context.SaveChangesAsync(cancellationToken);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _context.Dispose();
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
        var entries = _context.ChangeTracker.Entries()
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
}
