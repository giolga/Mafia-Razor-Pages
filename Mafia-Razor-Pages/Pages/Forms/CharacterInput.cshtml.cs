using Mafia_Razor_Pages.Data;
using Mafia_Razor_Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mafia_Razor_Pages.Pages.Forms
{
    [BindProperties(SupportsGet = true)]
    public class CharacterInputModel : PageModel
    {
        private readonly CharacterService _characterService;
        private readonly AppDbContext _context;
        public List<string> Characters => _characterService.Characters.ToList();

        [BindProperty]
        public string Character { get; set; }
        [BindProperty]
        public byte NumberOfPlayers { get; set; }

        public CharacterInputModel(CharacterService characterService, AppDbContext context)
        {
            this._characterService = characterService;
            this._context = context;
            NumberOfPlayers = (byte)_context.Players.Count();
        }


        public void OnGet()
        {
            // Fetch characters if needed
        }

        public void OnPost()
        {
            if (!string.IsNullOrWhiteSpace(Character) && NumberOfPlayers > 0)
            {
                _characterService.Characters.Add(Character);
                NumberOfPlayers--;
                Console.WriteLine(_characterService.Characters.Count + " " + NumberOfPlayers);
            }

            // Redirect to refresh the list on the page
            //return Page();
        }
    }
}
