using AnimeListAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Infrastructure.Configurations;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        /*builder
            .HasKey(entity => entity.Id);

        builder
            .HasMany(m => m.Movies)
            .WithOne(l => l.Language);

        builder
            .HasMany(s => s.Series)
            .WithOne(l => l.Language);*/
    }
}
