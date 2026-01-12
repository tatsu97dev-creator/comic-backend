using Comic.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comic.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Work> Works { get; set; } = null!;
    public DbSet<Work> Authors { get; set; } = null!;
    public DbSet<Work> Publishers { get; set; } = null!;
}
