using AnimeList.Domain.Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Infrastructure.Database.Configurations;

internal sealed class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> entityTypeBuilder)
    {
        entityTypeBuilder.ToTable("Country", "dbo");

        entityTypeBuilder.HasKey(entity => entity.Id);

        entityTypeBuilder.Property(entity => entity.Name)
            .HasColumnType("varchar(25)")
            .HasMaxLength(25)
            .IsRequired();
    }
}
