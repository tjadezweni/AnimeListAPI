using AnimeList.Domain.Serieses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Infrastructure.Database.Configurations;

internal class SeriesConfiguration : IEntityTypeConfiguration<Series>
{
    public void Configure(EntityTypeBuilder<Series> entityTypeBuilder)
    {
        entityTypeBuilder.ToTable("Series", "dbo");

        entityTypeBuilder.HasKey(entity => entity.Id);

        entityTypeBuilder.Property(entity => entity.Title)
            .HasColumnType("varchar(20)")
            .HasMaxLength(20)
            .IsRequired();

        entityTypeBuilder.Property(entity => entity.Description)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .IsRequired();

        entityTypeBuilder.Property<DateTime>(entity => entity.YearStarted)
            .IsRequired();

        entityTypeBuilder.Property<DateTime>(entity => entity.YearEnded);

        entityTypeBuilder.Property(entity => entity.Seasons)
            .IsRequired();

        entityTypeBuilder.Property(entity => entity.Episodes)
            .IsRequired();

        entityTypeBuilder.Property(entity => entity.IsCompleted)
            .IsRequired();

        entityTypeBuilder.HasOne(entity => entity.Genre)
            .WithMany(referencedEntity => referencedEntity.Series)
            .HasForeignKey(entity => entity.GenreId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        entityTypeBuilder.HasOne(entity => entity.Studio)
            .WithMany(referencedEntity => referencedEntity.Series)
            .HasForeignKey(entity => entity.StudioId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        entityTypeBuilder.HasOne(entity => entity.Language)
            .WithMany(referencedEntity => referencedEntity.Series)
            .HasForeignKey(entity => entity.LanguageId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        entityTypeBuilder.HasOne(entity => entity.Country)
            .WithMany(referencedEntity => referencedEntity.Series)
            .HasForeignKey(entity => entity.CountryId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}
