namespace TheBillboard.Data.Data;

using Microsoft.EntityFrameworkCore;
using Models;

public class TheBillboardContext : DbContext
{
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Message> Messages { get; set; } = null!;
    
    public TheBillboardContext(DbContextOptions<TheBillboardContext> options) : base(options)
    {
    }
}