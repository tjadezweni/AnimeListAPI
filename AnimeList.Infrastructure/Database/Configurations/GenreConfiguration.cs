using AnimeList.Domain.Genres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Infrastructure.Database.Configurations;

internal sealed class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> entityTypeBuilder)
    {
        entityTypeBuilder.ToTable("Genres", "dbo");

        entityTypeBuilder.HasKey(entity => entity.Id);

        entityTypeBuilder.Property(entity => entity.Name)
            .HasColumnType("varchar(20)")
            .HasMaxLength(20)
            .IsRequired();
    }
}
