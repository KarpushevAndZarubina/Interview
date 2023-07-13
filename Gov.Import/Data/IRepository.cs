using System.Linq.Expressions;

namespace Gov.Import.Data;
public interface IRepository<T>
{
    List<T> List(Expression<Func<T, bool>> where = null);
    T Find(Expression<Func<T, bool>> predicate);
    Task<T> FindAsync(Expression<Func<T, bool>> predicate);
    void Insert(T Entity);
    Task InsertAsync(IEnumerable<T> EntityList);
    void Update(T Entity);
    void Update(IEnumerable<T> EntityList);
    void Delete(T Entity);
    Task DeleteAsync(IEnumerable<T> EntityList);
    void Clear();
}
