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

        public byte RemainingSlots { get; private set; }

        public CharacterInputModel(CharacterService characterService, AppDbContext context)
        {
            _characterService = characterService;
            _context = context;
        }

        public void OnGet()
        {
            UpdateRemainingSlots();
        }

        public IActionResult OnPost()
        {
            UpdateRemainingSlots();

            // Validation: Check if character is empty
            if (string.IsNullOrWhiteSpace(Character))
            {
                ModelState.AddModelError(nameof(Character), "Character name is required.");
                return Page();
            }

            // Validation: Check if slots are full
            if (RemainingSlots <= 0)
            {
                ModelState.AddModelError(nameof(Character), "No slots remaining to add a new character.");
                return Page();
            }

            // Add the character if validations pass
            _characterService.Characters.Add(Character);

            // Redirect to refresh the page and update UI
            return RedirectToPage();
        }

        private void UpdateRemainingSlots()
        {
            var totalPlayers = (byte)_context.Players.Count();
            RemainingSlots = (byte)(totalPlayers - _characterService.Characters.Count);
        }
    }
}
