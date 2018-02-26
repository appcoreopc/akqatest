using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AkqaDataServices.DataModel
{
    public interface IAkqaDataContext
    {
        DbSet<UserAmount> UserAmount { get; }

        int SaveChanges();
      
        TEntity Find<TEntity>(params object[] keyValues) where TEntity : class;

        EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;

        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;

        EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;

    }

}
