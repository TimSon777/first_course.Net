using System.Threading.Tasks;

namespace DB.Database.Definition
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> AddAndSaveAsync(TEntity entity);
        Task<TEntity> FindAsync(int id);
    }
}