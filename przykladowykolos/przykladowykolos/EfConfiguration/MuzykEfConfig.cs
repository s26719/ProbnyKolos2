using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using przykladowykolos.Models;

namespace przykladowykolos.EfConfiguration;

public class MuzykEfConfig : IEntityTypeConfiguration<Muzyk>
{
    public void Configure(EntityTypeBuilder<Muzyk> builder)
    {
        builder.ToTable("Muzyk");
        builder.HasKey(m => m.IdMuzyk);
        builder.Property(m => m.IdMuzyk).ValueGeneratedOnAdd();

        builder.Property(m => m.Imie).HasMaxLength(30).IsRequired();
        builder.Property(m => m.Nazwisko).HasMaxLength(40).IsRequired();
        builder.Property(m => m.Pseudonim).HasMaxLength(50).IsRequired(false);

        builder.HasMany(m => m.WykonawcaUtworu)
            .WithOne(wu => wu.IdMuzykNavigation)
            .HasForeignKey(wu => wu.IdMuzyk)
            .OnDelete(DeleteBehavior.Cascade);
    }
}