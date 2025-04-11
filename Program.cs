using BookManager.Models; // zakładam, że Twoja klasa kontekstu jest w tym namespace
using BookManager.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<AppDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.SlidingExpiration = false;
    options.Cookie.IsEssential = true;
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";

    options.ExpireTimeSpan = TimeSpan.FromMinutes(30); 
    options.SlidingExpiration = false;
    options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
});


builder.Services.AddRazorPages(); // wymagane do obsługi Areas

builder.Services.AddHttpClient<CurrencyService>();
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
app.MapRazorPages(); // na końcu konfiguracji routingu

app.UseAuthentication(); // dodaj PRZED app.UseAuthorization()
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
