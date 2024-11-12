using Mafia_Razor_Pages.Models;
using Microsoft.EntityFrameworkCore;

namespace Mafia_Razor_Pages.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Player> Players { get; set; }
    }
}
