using Microsoft.EntityFrameworkCore;
using TheBillboard.Data.Abstract;
using TheBillboard.Data.Data;
using TheBillboard.Data.Gateways;
using TheBillboard.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGateway<Message>, MessageGateway>();
builder.Services.AddScoped<IGateway<Author>, AuthorGateway>();

builder.Services.AddDbContext<TheBillboardContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();