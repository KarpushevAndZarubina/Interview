using System.Diagnostics;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

namespace Gov.Import.Data;
public class DbRepository<TEntity, TContext> : IRepository<TEntity>
 where TEntity : class, new()
 where TContext : Microsoft.EntityFrameworkCore.DbContext
{
    private readonly IDbContextFactory<TContext> dBContextFactory;

    public DbRepository(IDbContextFactory<TContext> DBContextFactory)
    {
        dBContextFactory = DBContextFactory;
    }

    public List<TEntity> List(Expression<Func<TEntity, bool>> where = null)
    {
        using var dbContext = dBContextFactory.CreateDbContext();
        dbContext.Database.EnsureCreated();

        var set = dbContext.Set<TEntity>();
        if (where != null) return set.Where(where).ToList();
        return set.ToList();
    }

    public TEntity Find(Expression<Func<TEntity, bool>> predicate)
    {
        using var dbContext = dBContextFactory.CreateDbContext();
        return dbContext.Set<TEntity>().AsQueryable().Where(predicate).FirstOrDefault();
    }

    public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate) => Task.Run(() => Find(predicate));

    public void Delete(TEntity entity)
    {
        using var dbContext = dBContextFactory.CreateDbContext();
        dbContext.Set<TEntity>().Remove(entity);
        dbContext.SaveChanges();
    }


    public async Task DeleteAsync(IEnumerable<TEntity> entityList)
    {
        using var dbContext = dBContextFactory.CreateDbContext();
        await dbContext.Set<TEntity>().BulkDeleteAsync(entityList);
        dbContext.SaveChanges();
    }

    public void Insert(TEntity entity)
    {
        using var dbContext = dBContextFactory.CreateDbContext();
        dbContext.Set<TEntity>().Add(entity);
        dbContext.SaveChanges();
    }

    public async Task InsertAsync(IEnumerable<TEntity> entityList)
    {
        //добавляем новые записи
        using var dbContext = dBContextFactory.CreateDbContext();
        await dbContext.Set<TEntity>().BulkInsertAsync(entityList);
        dbContext.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        using var dbContext = dBContextFactory.CreateDbContext();
        if (dbContext.Entry(entity).State == EntityState.Detached)
            try
            {
                dbContext.Set<TEntity>().Attach(entity);
                dbContext.Entry(entity).State = EntityState.Unchanged;
            }
            catch (Exception ex) { Debug.Write(ex); }

        try { dbContext.Entry(entity).State = EntityState.Modified; } catch (Exception ex) { Debug.Write(ex); }
        dbContext.SaveChanges();
    }

    public void Update(IEnumerable<TEntity> entityList)
    {
        using var dbContext = dBContextFactory.CreateDbContext();
        //dbContext.Database.SetCommandTimeout(TimeSpan.FromMinutes(10));

        foreach (var entity in entityList)
        {
            if (dbContext.Entry(entity).State == EntityState.Detached)
                try
                {
                    dbContext.Set<TEntity>().Attach(entity);
                    dbContext.Entry(entity).State = EntityState.Unchanged;
                }
                catch (Exception ex) { Debug.Write(ex); }

            try { dbContext.Entry(entity).State = EntityState.Modified; } catch (Exception ex) { Debug.Write(ex); }

        }

        dbContext.SaveChanges();
    }

    public void Clear()
    {
        using var dbContext = dBContextFactory.CreateDbContext();
        dbContext.Set<TEntity>().RemoveRange(List());
        dbContext.SaveChanges();
    }


}
