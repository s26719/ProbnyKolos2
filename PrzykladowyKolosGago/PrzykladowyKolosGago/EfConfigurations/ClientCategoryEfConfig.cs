using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrzykladowyKolosGago.Models;

namespace PrzykladowyKolosGago.EfConfigurations;

public class ClientCategoryEfConfig : IEntityTypeConfiguration<ClientCategory>
{
    public void Configure(EntityTypeBuilder<ClientCategory> builder)
    {
        builder.ToTable("ClientCategory");
        builder.HasKey(cc => cc.IdClientCategory);
        builder.Property(cc => cc.IdClientCategory).ValueGeneratedOnAdd();

        builder.Property(cc => cc.Name).HasMaxLength(100).IsRequired();
        builder.Property(cc => cc.DiscountPerc).IsRequired();

        builder.HasMany(cc => cc.Clients)
            .WithOne(c => c.IdClientCategoryNavigation)
            .HasForeignKey(c => c.IdClientCategory);


    }
}