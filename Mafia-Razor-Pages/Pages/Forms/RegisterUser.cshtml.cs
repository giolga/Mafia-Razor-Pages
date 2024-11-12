using Mafia_Razor_Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mafia_Razor_Pages.Pages.Forms
{
    public class RegisterUserModel : PageModel
    {
        [BindProperty]
        public Player player { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            return RedirectToPage("/Checkout/Checkout", player);
        }
    }
}
