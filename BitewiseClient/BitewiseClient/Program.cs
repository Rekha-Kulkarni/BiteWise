using BitewiseClient.Data;
using BitewiseClient.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();     // MVC
builder.Services.AddRazorPages();              // Needed for Blazor components
builder.Services.AddServerSideBlazor();        // Enables Blazor interactivity

// Configure EF Core DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add application services
builder.Services.AddScoped<ReceipeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map Blazor hub for interactive components
app.MapBlazorHub();

// Optional: fallback to home if route not found
app.MapFallbackToController("Index", "Home");

app.Run();
