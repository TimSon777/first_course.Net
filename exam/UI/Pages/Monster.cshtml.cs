using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
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
            if (ModelState.IsValid) return;
            
            var response = await _client.PostAsJsonAsync(_urlAddingMonster, MonsterModel);
            
            using var sr = new StreamReader(await response.Content.ReadAsStreamAsync());
            var json = await sr.ReadToEndAsync();
            var isSuccess = JsonSerializer.Deserialize<bool>(json);

            IActionResult a = new JsonResult("werg");
            
            if (!isSuccess)
            {
                ModelState.AddModelError("", "Что-то пошло не так, повторите попытку или попробуйте позже");
            }
        }
    }
}