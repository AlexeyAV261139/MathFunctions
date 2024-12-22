using ISOCI.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ISOCI.DAL;

public class ApplicationContext : DbContext
{
    public DbSet<ExpressionEntity> Expressions { get; set; } = null!;
    public DbSet<HistoryEntity> History { get; set; } = null!;
    public DbSet<AdminParamsEntity> AdminParams { get; set; } = null!;
    public DbSet<UserParamsEntity> UserParams { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MathExpr;Username=postgres;Password=qwerty");
    }
}