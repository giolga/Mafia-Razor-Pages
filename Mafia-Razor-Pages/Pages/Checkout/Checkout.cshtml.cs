using Mafia_Razor_Pages.Data;
using Mafia_Razor_Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mafia_Razor_Pages.Pages.Checkout
{
    [BindProperties(SupportsGet = true)]
    public class CheckoutModel : PageModel
    {
        public Player registeredPlayer {  get; set; }
        private readonly AppDbContext _context;

        public CheckoutModel(AppDbContext context)
        {
            this._context = context;
        }
        public void OnGet()
        {
            _context.Players.Add(registeredPlayer);
            _context.SaveChanges();
        }
    }
}
