using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrzykladowyKolosGago.Models;

namespace PrzykladowyKolosGago.EfConfigurations;

public class ReservationEfConfig : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.ToTable("Reservation");
        builder.HasKey(r => r.IdReservation);
        builder.Property(r => r.IdReservation).ValueGeneratedOnAdd();

        builder.Property(r => r.DateFrom).IsRequired();
        builder.Property(r => r.DateTo).IsRequired();
        builder.Property(r => r.Capacity).IsRequired();
        builder.Property(r => r.NumOfBoats).IsRequired();
        builder.Property(r => r.Fulfilled).IsRequired();
        builder.Property(r => r.Price).IsRequired(false);
        builder.Property(r => r.CancelReason).IsRequired(false);

        builder.HasOne(r => r.IdClientNavigation)
            .WithMany(c => c.Reservations)
            .HasForeignKey(r => r.IdClient)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(r => r.IdBoatStandardNavigation)
            .WithMany(bs => bs.Reservations)
            .HasForeignKey(r => r.IdBoatStandrd)
            .OnDelete(DeleteBehavior.NoAction);
        // migracja byla bez tego
        builder.HasMany(r => r.SailboatReservations)
            .WithOne(sr => sr.IdReservationNavigation)
            .HasForeignKey(sr => sr.IdReservation)
            .OnDelete(DeleteBehavior.NoAction);

    }
}