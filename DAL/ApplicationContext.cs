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

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        :base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
    }      

}