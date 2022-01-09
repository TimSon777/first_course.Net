using System.Threading.Tasks;
using DB.Database.Models;
using DB.Database.MonsterDirectory;
using Microsoft.AspNetCore.Mvc;

namespace DB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DungeonAndDragonsMonsterCrud : ControllerBase
    {
        private readonly IMonsterRepository _monsterRepository;

        public DungeonAndDragonsMonsterCrud(IMonsterRepository monsterRepository)
            => _monsterRepository = monsterRepository;

        [HttpPost]
        [Route("AddMonster")]
        public async Task Post(Monster monster)
            => await _monsterRepository.AddAndSaveAsync(monster);

        [HttpGet]
        [Route("GetRandomMonster")]
        public async Task<Monster> Get()
            => await _monsterRepository.GetRandomMonster();
    }
}
