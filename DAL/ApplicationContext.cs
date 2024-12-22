using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ISOCI.DAL;

public class ApplicationContext : DbContext
{
    public DbSet<Formula> Furmulas { get; set; }
    public DbSet<History> History { get; set; }
    public DbSet<Parametr> Parametros { get; set; }
    public DbSet<ParametrValue> ParametrValues { get; set; }
    public DbSet<User> Users { get; set; } = null!;


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MathExpr;Username=postgres;Password=qwerty");
    }
}
