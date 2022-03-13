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
        builder
            .HasKey(entity => entity.MovieId);

        builder
            .HasOne(m => m.Genre)
            .WithMany()
            .HasForeignKey(f => f.GenreId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(m => m.Studio)
            .WithMany()
            .HasForeignKey(f => f.StudioId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(m => m.Language)
            .WithMany()
            .HasForeignKey(f => f.LanguageId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(m => m.Country)
            .WithMany()
            .HasForeignKey(f => f.CountryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
