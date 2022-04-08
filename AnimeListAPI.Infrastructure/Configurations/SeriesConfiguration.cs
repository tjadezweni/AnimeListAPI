using AnimeListAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Infrastructure.Configurations;

public class SeriesConfiguration : IEntityTypeConfiguration<Series>
{
    public void Configure(EntityTypeBuilder<Series> builder)
    {
        builder
            .HasKey(entity => entity.SeriesId);

        builder
            .HasQueryFilter(entity => !entity.IsDeleted);

        builder
            .HasOne(s => s.Genre)
            .WithMany()
            .HasForeignKey(s => s.GenreId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(s => s.Studio)
            .WithMany()
            .HasForeignKey(f => f.StudioId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(s => s.Country)
            .WithMany()
            .HasForeignKey(f => f.CountryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(s => s.Language)
            .WithMany()
            .HasForeignKey(f => f.LanguageId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
