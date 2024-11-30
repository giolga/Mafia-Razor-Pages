using Mafia_Razor_Pages.Data;
using Mafia_Razor_Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Mafia_Razor_Pages.Pages
{
    public class SelectionModel : PageModel
    {
        public List<string> MyCharacters { get; set; }
        public readonly AppDbContext _context;

        public SelectionModel(AppDbContext context)
        {
            this._context = context;
        }

        public void OnGet()
        {
            var charactersJson = HttpContext.Session.GetString("MyCharacters");

            // Debugging: Log the retrieved session value
            Console.WriteLine("Characters retrieved from session: " + charactersJson);

            if (charactersJson != null)
            {
                // Deserialize the JSON string back into a list
                MyCharacters = JsonConvert.DeserializeObject<List<string>>(charactersJson);
            }
            else
            {
                // If no characters found, initialize an empty list
                MyCharacters = new List<string>();
                Console.WriteLine("No characters in session.");
            }
        }

        public IActionResult OnPostOrganizeCharacters()
        {
            // Retrieve characters from session
            var charactersJson = HttpContext.Session.GetString("MyCharacters");
            if(charactersJson is null)
            {
                return RedirectToPage("/Forms/CharacterInput");
            }

            var availableCharacters = JsonConvert.DeserializeObject<List<string>>(charactersJson);

            // Get all players
            var players = _context.Players.ToList();

            // Shuffle characters
            var shuffledCharacters = availableCharacters.OrderBy(x => Guid.NewGuid()).ToList();

            // Assign characters randomly
            for (int i = 0; i < Math.Min(players.Count, shuffledCharacters.Count); i++)
            {
                players[i].Character = shuffledCharacters[i];
            }

            _context.SaveChanges();

            return RedirectToPage();
        }

        public IActionResult OnPostOrganizeSeats()
        {
            // Get all players
            var players = _context.Players.ToList();

            // Generate a list of seat numbers
            var seatNumbers = Enumerable.Range(1, players.Count).ToList();

            // Shuffle seat numbers
            var shuffledSeats = seatNumbers.OrderBy(x => Guid.NewGuid()).ToList();

            // Assign seat numbers randomly
            for (int i = 0; i < players.Count; i++)
            {
                players[i].SeatNumber = (byte)shuffledSeats[i];
            }

            _context.SaveChanges();

            return RedirectToPage();
        }
    }
}
