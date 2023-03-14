using Entities.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Context;

public class PassManContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=PassManDb;TrustServerCertificate=True;User Id=sa;Password=Fth0606++;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Connection> Connections { get; set; }
    public DbSet<Calendar> Calendars { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<Control> Controls { get; set; }

}