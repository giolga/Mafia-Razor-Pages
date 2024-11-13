using Mafia_Razor_Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mafia_Razor_Pages.Pages.Forms
{
    [BindProperties(SupportsGet = true)]
    public class CharacterInputModel : PageModel
    {
        private readonly CharacterService _characterService;
        public List<string> Characters => _characterService.Characters.ToList();

        public CharacterInputModel(CharacterService characterService)
        {
            _characterService = characterService;
        }

        [BindProperty]
        public string Character { get; set; }

        public void OnGet()
        {
            // Fetch characters if needed
        }

        public void OnPost()
        {
            if (!string.IsNullOrWhiteSpace(Character))
            {
                _characterService.Characters.Add(Character);
                Console.WriteLine(_characterService.Characters.Count);
            }

            // Redirect to refresh the list on the page
        }
    }
}
