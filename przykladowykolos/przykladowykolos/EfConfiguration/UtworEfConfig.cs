using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using przykladowykolos.Models;

namespace przykladowykolos.EfConfiguration;

public class UtworEfConfig : IEntityTypeConfiguration<Utwor>
{
    public void Configure(EntityTypeBuilder<Utwor> builder)
    {
        builder.ToTable("Utwor");
        builder.HasKey(u => u.IdUtwor);
        builder.Property(u => u.IdUtwor).ValueGeneratedOnAdd();

        builder.Property(u => u.NazwaUtworu).HasMaxLength(30).IsRequired();
        builder.Property(u => u.CzasTrwania).IsRequired();
        builder.Property(u => u.IdAlbum).IsRequired(false);

        builder.HasMany(u => u.WykonawcaUtworu)
            .WithOne(wu => wu.IdUtworNavigation)
            .HasForeignKey(wu => wu.IdUtwor)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(u => u.IdAlbumNavigation)
            .WithMany(a => a.Utwors)
            .HasForeignKey(a => a.IdAlbum)
            .OnDelete(DeleteBehavior.Cascade).IsRequired(false);
    }
}