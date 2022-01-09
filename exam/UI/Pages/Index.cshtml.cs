using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models;

namespace UI.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public CharacterModel CharacterModel { get; init; }

        public void OnGet() {}
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            TempData["cm"] = JsonSerializer.Serialize(CharacterModel);
            return RedirectToPage("/Game");
        }
    }
}