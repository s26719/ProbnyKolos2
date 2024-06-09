using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using przykladowykolos.Models;

namespace przykladowykolos.EfConfiguration;

public class WytworniaEfConfig : IEntityTypeConfiguration<Wytwornia>
{
    public void Configure(EntityTypeBuilder<Wytwornia> builder)
    {
        builder.ToTable("Wytwornia");
        builder.HasKey(w => w.IdWytwornia);
        builder.Property(w => w.IdWytwornia).ValueGeneratedOnAdd();

        builder.Property(w => w.Nazwa).HasMaxLength(50).IsRequired();

        builder.HasMany(w => w.Albums)
            .WithOne(a => a.idWytworniaNagivation)
            .HasForeignKey(a => a.IdWytwornia);
    }
}