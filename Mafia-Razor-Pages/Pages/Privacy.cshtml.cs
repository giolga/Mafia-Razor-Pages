using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;

namespace Mafia_Razor_Pages.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly IConfiguration _config;

        public PrivacyModel(ILogger<PrivacyModel> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public async Task<IActionResult> OnPostUpdateDatabaseAsync()
        {
            var connection = new SqliteConnection(_config.GetConnectionString("DefaultConnection"));
            _logger.LogInformation($"Using SQLite connection string: {connection}");

            try
            {
                await connection.OpenAsync();
                await connection.ExecuteAsync("DELETE FROM Players");
                await connection.ExecuteAsync("DELETE FROM GameActions");
                await connection.ExecuteAsync(@"
                        DELETE FROM sqlite_sequence WHERE name = 'Players';
                        DELETE FROM sqlite_sequence WHERE name = 'GameActions';
                        REINDEX Players;
                        REINDEX GameActions;
                    ");

                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while clearing the database.");
                return BadRequest("An error occurred: " + ex.Message);
            }
            finally
            {
                await connection.CloseAsync();
            }

            return RedirectToPage("/Privacy");
        }
    }

}
