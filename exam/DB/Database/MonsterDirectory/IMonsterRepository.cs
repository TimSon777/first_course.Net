using System.Threading.Tasks;
using DB.Database.Definition;
using DB.Database.Models;

namespace DB.Database.MonsterDirectory
{
    public interface IMonsterRepository : IRepository<Monster>
    {
        Task<Monster> GetRandomMonster();
    }
}