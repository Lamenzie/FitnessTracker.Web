using FitnessTracker.Application.Interfaces;
using FitnessTracker.Domain.Identity;
using FitnessTracker.Infrastructure.Database;
using FitnessTracker.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IExerciseAppService, ExerciseAppService>();

// Pøipojení k MySQL
string connectionString = builder.Configuration.GetConnectionString("MySQL");
ServerVersion serverVersion = new MySqlServerVersion(new Version(8, 0, 38));

builder.Services
    .AddIdentity<AppUser, AppRole>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 6;
    })
    .AddEntityFrameworkStores<FitnessTrackerDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddDbContext<FitnessTrackerDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

// ===== Identity cookies (kam se pøesmìruje nepøihlášený uživatel) =====
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Security/Account/Login";
    options.AccessDeniedPath = "/Security/Account/Login";
});

// ===== aplikaèní služba pro login / register =====
builder.Services.AddScoped<IAccountService, AccountIdentityService>();

var app = builder.Build();

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

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
