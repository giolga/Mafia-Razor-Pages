using Mafia_Razor_Pages.Data;
using Mafia_Razor_Pages.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
        }
    );
builder.Services.AddSingleton<CharacterService>();

// Add session support... this and line 41 for CharacterInput -> Selection page 
builder.Services.AddDistributedMemoryCache(); // Required for session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable session middleware
app.UseSession(); // Add this line to enable session support

app.UseAuthorization();

app.MapRazorPages();

app.Run();
