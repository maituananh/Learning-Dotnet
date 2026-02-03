using Application.Configurations;
using Infra.Configuration;

namespace Infra.Configurations;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context = context;

    private bool disposedValue;

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
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
}
