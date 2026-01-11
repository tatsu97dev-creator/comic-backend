using Comic.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comic.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Work> Works { get; set; } = null!;
}
