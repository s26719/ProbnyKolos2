using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrzykladowyKolosGago.Models;

namespace PrzykladowyKolosGago.EfConfigurations;

public class ClientEfConfig : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Client");
        builder.HasKey(c => c.IdClient);
        builder.Property(c => c.IdClient).ValueGeneratedOnAdd();

        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        builder.Property(c => c.LastName).HasMaxLength(100).IsRequired();
        builder.Property(c => c.Birthday).IsRequired();
        builder.Property(c => c.Pesel).HasMaxLength(100).IsRequired();
        builder.Property(c => c.Email).HasMaxLength(100).IsRequired();

        builder.HasOne(c => c.IdClientCategoryNavigation)
            .WithMany(cc => cc.Clients)
            .HasForeignKey(c => c.IdClientCategory);

        builder.HasMany(c => c.Reservations)
            .WithOne(r => r.IdClientNavigation)
            .HasForeignKey(r => r.IdClient);

    }
}