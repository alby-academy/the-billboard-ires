namespace TheBillboard.MVC;

using Data.Data;
using Microsoft.EntityFrameworkCore;

public static class Bootstrapper
{
    public static async Task MigrateAsync(this WebApplication app)
    {
        var provider = app.Services.CreateScope();
        var context = provider.ServiceProvider.GetRequiredService<TheBillboardContext>();
        
        await context.Database.MigrateAsync();
    }
}