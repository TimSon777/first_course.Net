using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models;

namespace UI.Pages
{
    public class Monster : PageModel
    {
        private readonly HttpClient _client = new();
        private readonly Uri _urlAddingMonster = new("https://localhost:5005/DungeonAndDragonsMonsterCrud/AddMonster");

        [BindProperty] 
        public MonsterModel MonsterModel { get; init; }

        public void OnGet()
        { }

        public async Task OnPost()
        {
            if (!ModelState.IsValid) return;
            await _client.PostAsJsonAsync(_urlAddingMonster, MonsterModel);
        }
    }
}