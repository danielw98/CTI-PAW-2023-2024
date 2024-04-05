using Lab04_Gr362.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab04_Gr362.ContextModels;

public class StiriContext : DbContext
{
    public DbSet<Stire> Stire { get; set; }
    public DbSet<Categorie> Categorie { get; set; }
    public StiriContext(DbContextOptions<StiriContext> options) : base(options) { }
}
