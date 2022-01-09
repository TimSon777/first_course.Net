using System;
using System.Linq;
using System.Threading.Tasks;
using DB.Database.Definition;
using DB.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DB.Database.MonsterDirectory
{
    public class MonsterRepository : Repository<Monster>, IMonsterRepository
    {
        public MonsterRepository(ApplicationDbContext appDbContext) 
            : base(appDbContext)
        { }
        
        public async Task<Monster> AddAndSaveAsync(Monster entity)
            => await AddAndSaveCommonAsync(entity);

        public Task<Monster> FindAsync(int id)
            => FindCommonAsync(id);
        
        
        public async Task<Monster> GetRandomMonster()
        {
            var count = await AppDbContext.Monsters.CountAsync();

            if (count == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            var rndSkip = new Random().Next(0, count);
            return await AppDbContext.Monsters.Skip(rndSkip).FirstAsync();
        }
    }
}