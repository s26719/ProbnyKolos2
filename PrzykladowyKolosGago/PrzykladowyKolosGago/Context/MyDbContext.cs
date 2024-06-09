using Microsoft.EntityFrameworkCore;
using PrzykladowyKolosGago.EfConfigurations;
using PrzykladowyKolosGago.Models;

namespace PrzykladowyKolosGago.Context;

public class MyDbContext : DbContext
{

    public DbSet<ClientCategory> ClientCategories { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<BoatStandard> BoatStandards { get; set; }
    public DbSet<Sailboat_Reservation> SailboatReservations { get; set; }
    public DbSet<Sailboat> Sailboats { get; set; }
    
    protected MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BoatStandardEfConfig());
        modelBuilder.ApplyConfiguration(new ClientEfConfig());
        modelBuilder.ApplyConfiguration(new ClientCategoryEfConfig());
        modelBuilder.ApplyConfiguration(new SailboatEfConfig());
        modelBuilder.ApplyConfiguration(new Sailboat_ReservationEfConfig());
        modelBuilder.ApplyConfiguration(new ReservationEfConfig());
    }
}