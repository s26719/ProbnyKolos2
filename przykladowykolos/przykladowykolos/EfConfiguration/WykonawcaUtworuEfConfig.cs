using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using przykladowykolos.Models;

namespace przykladowykolos.EfConfiguration;

public class WykonawcaUtworuEfConfig : IEntityTypeConfiguration<WykonawcaUtworu>
{
    public void Configure(EntityTypeBuilder<WykonawcaUtworu> builder)
    {
        builder.ToTable("WykonawcaUtworu");
        builder.HasKey(wu => new { wu.IdMuzyk, wu.IdUtwor });
        builder.HasOne(wu => wu.IdMuzykNavigation)
            .WithMany(m => m.WykonawcaUtworu)
            .HasForeignKey(m => m.IdMuzyk);
    }
}