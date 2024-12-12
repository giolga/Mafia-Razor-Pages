using Mafia_Razor_Pages.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mafia_Razor_Pages.Pages
{
    public class GameModel : PageModel
    {
        public readonly AppDbContext _context;

        public GameModel(AppDbContext context)
        {
            this._context = context;
        }

        public void OnGet()
        {
        }
    }
}
