using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models;
using UI.Models.UnionModels;

namespace UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Uri _urlGettingRandomMonster 
            = new("https://localhost:5005/DungeonAndDragonsMonsterCrud/GetRandomMonster");
        
        private readonly HttpClient _client = new();

        [BindProperty]
        public CharacterModel CharacterModel { get; init; }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();
            
            var monster = await _client.GetFromJsonAsync<MonsterModel>(_urlGettingRandomMonster);
            var cm = new CharacterMonster(CharacterModel, monster);
            return RedirectToPage("/Game", new { cm });
        }
    }
}