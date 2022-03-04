using AnimeListAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Infrastructure.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        /*builder
            .HasKey(entity => entity.Id);

        builder
            .HasMany(m => m.Movies)
            .WithOne(c => c.Country);

        builder
            .HasMany(s => s.Series)
            .WithOne(c => c.Country);*/
    }
}
