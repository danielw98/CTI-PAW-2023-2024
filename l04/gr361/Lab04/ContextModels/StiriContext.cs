using Lab04_Gr361.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab04_Gr361.ContextModels;

public class StiriContext : DbContext
{
    public DbSet<Stire> Stiri { get; set; }
    public DbSet<Categorie> Categorie { get; set; }
    public StiriContext(DbContextOptions<StiriContext> options) : base(options) { }
}