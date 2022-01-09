using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DB.Database.Definition
{
    public class Repository<TEntity> 
        where TEntity : class
    {
        protected readonly ApplicationDbContext AppDbContext;
        private readonly DbSet<TEntity> _dbSet;

        // ReSharper disable once MemberCanBeProtected.Global
        public Repository(ApplicationDbContext appDbContext)
        {
            AppDbContext = appDbContext;
            _dbSet = AppDbContext.Set<TEntity>();
        }

        protected async Task<TEntity> AddAndSaveCommonAsync(TEntity entity)
        {
            var entityUp = await _dbSet.AddAsync(entity);
            await AppDbContext.SaveChangesAsync();
            return entityUp.Entity;
        }

        protected async Task<TEntity> FindCommonAsync(int id)
            => await _dbSet.FindAsync(id);
    }
}