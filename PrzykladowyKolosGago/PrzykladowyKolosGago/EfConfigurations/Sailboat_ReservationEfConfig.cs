using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrzykladowyKolosGago.Models;

namespace PrzykladowyKolosGago.EfConfigurations;

public class Sailboat_ReservationEfConfig : IEntityTypeConfiguration<Sailboat_Reservation>
{
    public void Configure(EntityTypeBuilder<Sailboat_Reservation> builder)
    {
        builder.ToTable("Sailboat_Reservation");
        builder.HasKey(sr => new { sr.IdReservation, sr.IdSailboat });

        builder.HasOne(sr => sr.IdReservationNavigation)
            .WithMany(r => r.SailboatReservations)
            .HasForeignKey(sr => sr.IdReservation)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(sr => sr.IdSailboatNavigation)
            .WithMany(s => s.SailboatReservations)
            .HasForeignKey(sr => sr.IdSailboat)
            .OnDelete(DeleteBehavior.NoAction);
    }
}