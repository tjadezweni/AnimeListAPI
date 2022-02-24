using AnimeList.Domain.Movies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Infrastructure.Database.Configurations;

internal sealed class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> entityTypeBuilder)
    {
        entityTypeBuilder.ToTable("Movies", "dbo");

        entityTypeBuilder.HasKey(entity => entity.Id);

        entityTypeBuilder.Property(entity => entity.Title)
            .HasColumnType("varchar(20)")
            .HasMaxLength(20)
            .IsRequired();

        entityTypeBuilder.Property(entity => entity.Description)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .IsRequired();

        entityTypeBuilder.Property<DateTime>(entity => entity.YearReleased)
            .IsRequired();

        entityTypeBuilder.HasOne(entity => entity.Genre)
            .WithMany()
            .HasForeignKey(entity => entity.GenreId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        entityTypeBuilder.HasOne(entity => entity.Studio)
            .WithMany()
            .HasForeignKey(entity => entity.StudioId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        entityTypeBuilder.HasOne(entity => entity.Language)
            .WithMany()
            .HasForeignKey(entity => entity.LanguageId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        entityTypeBuilder.HasOne(entity => entity.Country)
            .WithMany()
            .HasForeignKey(entity => entity.CountryId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}
