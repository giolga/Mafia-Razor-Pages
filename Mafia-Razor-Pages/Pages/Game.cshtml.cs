using Mafia_Razor_Pages.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mafia_Razor_Pages.Pages
{
    public class GameModel : PageModel
    {
        public readonly AppDbContext _context;
        private readonly ILogger<GameModel> _logger;

        [BindProperty]
        public string SelectedCharacter { get; set; }

        public GameModel(AppDbContext context, ILogger<GameModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(SelectedCharacter))
            {
                ModelState.AddModelError(string.Empty, "Please select a character.");
                Console.WriteLine("EMPTYYYYY");
                return Page();
            }

            _logger.LogDebug($"Selected Character: {SelectedCharacter}");

            // Example of doing something with the selected character
            switch (SelectedCharacter)
            {
                case "Don":
                    // Do something for Don
                    break;
                case "Mafia":
                    // Do something for Mafia
                    break;
                case "Serial Killer":
                    // Do something for Serial Killer
                    break;
                case "Detective":
                    // Do something for Detective
                    break;
            }

            return Page();
        }
    }
}
