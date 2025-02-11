using Mafia_Razor_Pages.Data;
using Mafia_Razor_Pages.Models;
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
        [BindProperty]
        public int Target { get; set; }
        public List<GameAction> GameActions { get; set; }


        public GameModel(AppDbContext context, ILogger<GameModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            GameActions = _context.GameActions.ToList();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(SelectedCharacter))
            {
                ModelState.AddModelError(string.Empty, "Please select a character.");
                Console.WriteLine("EMPTYYYYY");
                return RedirectToPage("./Game");
            }


            if (Target <= 0)
            {
                ModelState.AddModelError(string.Empty, "Please select a valid character!");
                return RedirectToPage("./Game");
            }

            var characterInTable = _context.GameActions.Where(g => g.Character == SelectedCharacter).ToList();

            if (characterInTable.Any(t => t.TargetSeatNumber == Target) && (SelectedCharacter == "Serial Killer" || SelectedCharacter == "Mafia" || SelectedCharacter == "Doctor")) // killer/mafia murdered player he can't kill the same player again!
            {
                ModelState.AddModelError(string.Empty, $"This character already selected: {Target}");
                Console.WriteLine($"This character already selected: {Target}");
                return RedirectToPage("");
            }

            if ((characterInTable.Count == 2 && SelectedCharacter == "Serial Killer")) // killer can't kill anymore
            {
                Console.WriteLine("Killer can't kill anymore!");
                return RedirectToPage("./Game");
            }


            var newAction = new GameAction
            {
                Character = SelectedCharacter,
                TargetSeatNumber = Target,
                TimeStamp = DateTime.Now
            };

            var player = _context.Players.FirstOrDefault(p => p.SeatNumber == Target);

            if (SelectedCharacter == "Doctor")
            {
                if (player != null)
                {
                    player.Lose = false;
                    _context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Can not heal! Error occured! (DOCTOR ERROR)");
                    return RedirectToPage("./Game");
                }
            }
            else if(SelectedCharacter == "Mafia" || SelectedCharacter == "Serial Killer")
            {
                if (player != null)
                {
                    player.Lose = true;
                    _context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Mafia/Killer can't kill! ERROR OCCURED!!!");
                    return RedirectToPage("./Game");
                }
            }

            _context.GameActions.Add(newAction);
            _context.SaveChanges();

            GameActions = _context.GameActions.ToList();

            return RedirectToPage("./Game");
        }
    }
}
