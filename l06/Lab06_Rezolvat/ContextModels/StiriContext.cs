using Lab05_Gr362.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab05_Gr362.ContextModels;

public class StiriContext : DbContext
{
    public DbSet<Stire> Stire { get; set; } = default!;
    public DbSet<Categorie> Categorie { get; set; } = default!;
    public StiriContext(DbContextOptions<StiriContext> options) : base(options) { }
}
