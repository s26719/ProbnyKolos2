using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrzykladowyKolosGago.Models;

namespace PrzykladowyKolosGago.EfConfigurations;

public class SailboatEfConfig : IEntityTypeConfiguration<Sailboat>
{
    public void Configure(EntityTypeBuilder<Sailboat> builder)
    {
        builder.ToTable("Sailboat");
        builder.HasKey(s => s.IdSailboat);
        builder.Property(s => s.IdSailboat).ValueGeneratedOnAdd();

        builder.Property(s => s.Name).HasMaxLength(100).IsRequired();
        builder.Property(s => s.Capacity).IsRequired();
        builder.Property(s => s.Description).HasMaxLength(100).IsRequired();
        builder.Property(s => s.Price).IsRequired();

        
        // migracja byla bez tego
        /*builder.HasMany(s => s.SailboatReservations)
            .WithOne(sr => sr.IdSailboatNavigation)
            .HasForeignKey(sr => sr.IdSailboat)
            .OnDelete(DeleteBehavior.NoAction);*/
            

        builder.HasOne(s => s.IdBoatStandardNavigation)
            .WithMany(bs => bs.Sailboats)
            .HasForeignKey(s => s.IdBoatStandard)
            .OnDelete(DeleteBehavior.NoAction);
    }
}