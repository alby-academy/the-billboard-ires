using Microsoft.EntityFrameworkCore;
using TheBillboard.Data.Data;
using TheBillboard.Data.Models;
using TheBillboard.MVC;
using TheBillboard.MVC.Abstract;
using TheBillboard.MVC.Gateways;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IGateway<Message>, MessageGateway>();
builder.Services.AddScoped<IGateway<Author>, AuthorGateway>();

builder.Services.AddDbContext<TheBillboardContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

await app.MigrateAsync();

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
    "default",
    "{controller=Home}/{action=Index}/{id?}");

await app.RunAsync();
