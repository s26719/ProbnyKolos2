using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using przykladowykolos.Models;

namespace przykladowykolos.EfConfiguration;

public class AlbumEfConfig : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.ToTable("Album");
        builder.HasKey(a => a.IdAlbum);
        builder.Property(a => a.IdAlbum).ValueGeneratedOnAdd();

        builder.Property(a => a.NazwaAlbumu).HasMaxLength(30).IsRequired();
        builder.Property(a => a.DataWydania).IsRequired();

        builder.HasOne(a => a.idWytworniaNagivation)
            .WithMany(w => w.Albums)
            .HasForeignKey(w => w.IdWytwornia)
            .OnDelete(DeleteBehavior.Cascade);
    }
}