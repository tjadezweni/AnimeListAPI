using AnimeListAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Infrastructure.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        /*builder
            .HasKey(entity => entity.Id);

        builder
            .HasOne(g => g.Genre)
            .WithMany(m => m.Movies)
            .HasForeignKey(f => f.GenreId);

        builder
            .HasOne(s => s.Studio)
            .WithMany(m => m.Movies)
            .HasForeignKey(f => f.StudioId);

        builder
            .HasOne(l => l.Language)
            .WithMany(m => m.Movies)
            .HasForeignKey(f => f.LanguageId);

        builder
            .HasOne(c => c.Country)
            .WithMany(m => m.Movies)
            .HasForeignKey(f => f.CountryId);*/
    }
}
