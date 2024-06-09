using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrzykladowyKolosGago.Models;

namespace PrzykladowyKolosGago.EfConfigurations;

public class BoatStandardEfConfig : IEntityTypeConfiguration<BoatStandard>
{
    public void Configure(EntityTypeBuilder<BoatStandard> builder)
    {
        builder.ToTable("BoatStandard");
        builder.HasKey(bs => bs.IdBoatStandard);
        builder.Property(bs => bs.IdBoatStandard).ValueGeneratedOnAdd();

        builder.Property(bs => bs.Name).HasMaxLength(100).IsRequired();
        builder.Property(bs => bs.Level).IsRequired();

        builder.HasMany(bs => bs.Reservations)
            .WithOne(r => r.IdBoatStandardNavigation)
            .HasForeignKey(r => r.IdBoatStandrd);
            

        builder.HasMany(bs => bs.Sailboats)
            .WithOne(s => s.IdBoatStandardNavigation)
            .HasForeignKey(s => s.IdBoatStandard);

    }
}