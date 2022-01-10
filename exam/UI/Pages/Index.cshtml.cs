using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models;
using UI.Models.CommonModels;
using UI.Models.Output;

namespace UI.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public CharacterModel CharacterModel { get; set; }
        public MonsterModel Monster { get; set; }
        private readonly HttpClient _client = new();
        public ResultFight ResultFight { get; set; }
        
        private readonly Uri _urlGettingRandomMonster 
            = new("https://localhost:5005/DungeonAndDragonsMonsterCrud/GetRandomMonster");
        
        private readonly Uri _urlPlayGame 
            = new("https://localhost:5003/GameDnd/Play");

        public void OnGet() { }
        public async Task OnPost()
        {
            if (!ModelState.IsValid) return;
            Monster = await _client.GetFromJsonAsync<MonsterModel>(_urlGettingRandomMonster);
            
            var gameData = new GameData
            {
                Character = CharacterModel,
                Monster = Monster
            };

            var resp = await _client.PostAsJsonAsync(_urlPlayGame, gameData);
            ResultFight = await resp.Content.ReadFromJsonAsync<ResultFight>();
            CharacterModel = ResultFight?.Character;
        }
    }
}