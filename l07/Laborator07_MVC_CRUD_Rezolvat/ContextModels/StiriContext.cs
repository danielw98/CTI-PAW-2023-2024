using Laborator07.Models;
using Microsoft.EntityFrameworkCore;

namespace Laborator07.ContextModels;

public class StiriContext : DbContext
{
    public StiriContext(DbContextOptions<StiriContext> options) : base(options)
    {
    }
    public DbSet<StireModel> Stire { get; set; }
    public DbSet<CategorieModel> Categorie { get; set; }
}
