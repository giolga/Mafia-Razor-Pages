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
    }
}
