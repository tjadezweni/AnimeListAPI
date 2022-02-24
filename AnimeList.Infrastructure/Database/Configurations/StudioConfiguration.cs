using AnimeList.Domain.Studios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Infrastructure.Database.Configurations;

internal sealed class StudioConfiguration : IEntityTypeConfiguration<Studio>
{
    public void Configure(EntityTypeBuilder<Studio> entityTypeBuilder)
    {
        entityTypeBuilder.ToTable("Studio", "dbo");

        entityTypeBuilder.HasKey(entity => entity.Id);

        entityTypeBuilder.Property(entity => entity.Name)
            .HasColumnType("varchar(20)")
            .HasMaxLength(20)
            .IsRequired();
    }
}
