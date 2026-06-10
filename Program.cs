using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using aspnet_crm_dashboard.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure port 5050 to avoid port conflicts
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5050);
});

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register CrmDbContext with SQLite
builder.Services.AddDbContext<CrmDbContext>(options =>
    options.UseSqlite("Data Source=crm_database.db"));

var app = builder.Build();

// Database Seeding and Initialization on Startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<CrmDbContext>();
        // Automatically creates database file and applies seeds on first run
        context.Database.EnsureCreated();
        Console.WriteLine("[Database] SQLite Initialized and Seeded Successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[Database] Initialization Error: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Set default controller mapping
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
