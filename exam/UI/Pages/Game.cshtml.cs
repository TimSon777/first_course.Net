using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models;
using UI.Models.UnionModels;

namespace UI.Pages
{
    public class Game : PageModel
    {
        public CharacterMonster CharacterMonster { get; set; }
        
        private readonly Uri _urlGettingRandomMonster 
            = new("https://localhost:5005/DungeonAndDragonsMonsterCrud/GetRandomMonster");
        
        private readonly HttpClient _client = new();
        
        public async Task<IActionResult> OnGet()
        {
            if (!TempData.TryGetValue("cm", out var obj))
            {
                return Redirect("/");
            }

            CharacterModel cm;
            try
            {
                cm = JsonSerializer.Deserialize<CharacterModel>((string) obj);
            }
            catch
            {
                return Redirect("/");
            }
            
            var monster = await _client.GetFromJsonAsync<MonsterModel>(_urlGettingRandomMonster);
            CharacterMonster = new CharacterMonster(cm, monster);
            return Page();
        }
    }
}