using AnimeListAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Infrastructure.Configurations;

public class StudioConfiguration : IEntityTypeConfiguration<Studio>
{
    public void Configure(EntityTypeBuilder<Studio> builder)
    {
        /*builder
            .HasKey(entity => entity.Id);

        builder
            .HasMany(m => m.Movies)
            .WithOne(s => s.Studio);

        builder
            .HasMany(s => s.Series)
            .WithOne(s => s.Studio);*/
    }
}
