using Microsoft.EntityFrameworkCore;
using przykladowykolos.EfConfiguration;
using przykladowykolos.Models;

namespace przykladowykolos.Context;

public class MyDbContext : DbContext
{
    
    public DbSet<Album> Albums { get; set; }
    public DbSet<Muzyk> Muzyks { get; set; }
    public DbSet<Utwor> Utwors { get; set; }
    public DbSet<WykonawcaUtworu> WykonawcaUtworus { get; set; }
    public DbSet<Wytwornia> Wytwornias { get; set; }
    
    protected MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AlbumEfConfig());
        modelBuilder.ApplyConfiguration(new MuzykEfConfig());
        modelBuilder.ApplyConfiguration(new UtworEfConfig());
        modelBuilder.ApplyConfiguration(new WykonawcaUtworuEfConfig());
        modelBuilder.ApplyConfiguration(new WytworniaEfConfig());
    }
}