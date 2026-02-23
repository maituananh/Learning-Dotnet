using System.Linq.Expressions;

namespace Domain.Repository;

public interface IRepository<T> where T : class
{
    public void Insert(T entity);
    public void Insert(IEnumerable<T> entities);
    public void Update(T entity);
    public void Delete(T entity);
    public void Delete(Expression<Func<T, bool>> expression);
    //public void Commit();
}
