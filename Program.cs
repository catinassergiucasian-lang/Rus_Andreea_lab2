using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rus_Andreea_lab2.Data;
using Rus_Andreea_lab2.Models;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});


// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Books");
    options.Conventions.AllowAnonymousToPage("/Books/Index");
    options.Conventions.AllowAnonymousToPage("/Books/Details");
    // MEMBERS – acces doar Admin
    options.Conventions.AuthorizeFolder("/Members", "AdminPolicy");

    // PUBLISHERS – acces doar Admin
    options.Conventions.AuthorizeFolder("/Publishers", "AdminPolicy");

    // CATEGORIES – acces doar Admin
    options.Conventions.AuthorizeFolder("/Categories", "AdminPolicy");
});


builder.Services.AddDbContext<Rus_Andreea_lab2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Rus_Andreea_lab2Context")
    ?? throw new InvalidOperationException("Connection string 'Rus_Andreea_lab2Context' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Rus_Andreea_lab2Context")
    ?? throw new InvalidOperationException("Connection string 'Rus_Andreea_lab2Context' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
