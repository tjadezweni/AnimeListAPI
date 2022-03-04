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
        /*builder
            .HasKey(entity => entity.Id);

        builder
            .HasOne(g => g.Genre)
            .WithMany(s => s.Series)
            .HasForeignKey(f => f.GenreId);

        builder
            .HasOne(s => s.Studio)
            .WithMany(s => s.Series)
            .HasForeignKey(f => f.StudioId);

        builder
            .HasOne(l => l.Language)
            .WithMany(s => s.Series)
            .HasForeignKey(f => f.LanguageId);

        builder
            .HasOne(c => c.Country)
            .WithMany(s => s.Series)
            .HasForeignKey(f => f.CountryId);*/
    }
}
