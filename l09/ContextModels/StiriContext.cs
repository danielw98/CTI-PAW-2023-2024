using Laborator09.Models;
using Microsoft.EntityFrameworkCore;

namespace Laborator09.ContextModels;

public class StiriContext : DbContext
{
    public StiriContext(DbContextOptions<StiriContext> options) : base(options)
    {
    }
    public DbSet<StireModel> Stire { get; set; }
    public DbSet<CategorieModel> Categorie { get; set; }
    public DbSet<UserModel> User { get; set; }
}
