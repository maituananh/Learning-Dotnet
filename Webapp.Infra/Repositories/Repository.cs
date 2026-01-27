using Infra.Configuration;
using System.Linq.Expressions;
using Application.Repository;

namespace Infra.Repository;

public class Repository<T>(ApplicationDbContext context) : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context = context;

    public IQueryable<T> Table => _context.Set<T>();

    public IEnumerable<T> GetAll(Expression<Func<T, bool>>? expression = null)
    {
        return expression != null ? _context.Set<T>().Where(expression) : _context.Set<T>();
    }

    public void Delete(T entity)
    {
        var entry = _context.Entry(entity);
        entry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
    }

    public void Delete(Expression<Func<T, bool>> expression)
    {
        var entities = _context.Set<T>().Where(expression).ToList();

        if (!entities.Any()) return;

        _context.Set<T>().RemoveRange(entities);
    }

    public void Insert(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Insert(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public void Update(T entity)
    {
        var entry = _context.Entry(entity);
        entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    }
}
