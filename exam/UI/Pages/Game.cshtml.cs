using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models.UnionModels;

namespace UI.Pages
{
    public class Game : PageModel
    {
        public CharacterMonster CharacterMonster { get; set; }
        
        public IActionResult OnGet(CharacterMonster cm)
        {
            if (cm?.Character is null || cm.Monster is null) return Redirect("/");
            CharacterMonster = cm;
            return Page();
        }
    }
}