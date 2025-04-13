/*
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Coffee_Shop2.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Coffee_Shop2ContextConnection") ?? throw new InvalidOperationException("Connection string 'Coffee_Shop2ContextConnection' not found.");

builder.Services.AddDbContext<Coffee_Shop2Context>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Coffee_Shop2Context>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add services for SQL server.
builder.Services.AddDbContext<CoffeeDbContext>(option => option.UseSqlServer(
    
    builder.Configuration.GetConnectionString("MyConn")

    ));

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
    pattern: "{controller=Home}/{action=about}/{id?}");
app.UseEndpoints(endpoints => endpoints.MapRazorPages());
app.Run();
*/

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Coffee_Shop2.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Coffee_Shop2ContextConnection")
    ?? throw new InvalidOperationException("Connection string 'Coffee_Shop2ContextConnection' not found.");

builder.Services.AddDbContext<Coffee_Shop2Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Coffee_Shop2Context>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services for SQL Server.
builder.Services.AddDbContext<CoffeeDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("MyConn")));

// Add services for Razor Pages (if used)
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Redirect HTTP to HTTPS
app.UseHttpsRedirection();

// Serve static files (e.g., CSS, images)
app.UseStaticFiles();

// Set up routing for controllers
app.UseRouting();

app.UseAuthorization();

// Map the default controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map Razor Pages (if used)
app.MapRazorPages();

app.Run();