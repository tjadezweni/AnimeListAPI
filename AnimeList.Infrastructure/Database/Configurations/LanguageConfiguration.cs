using AnimeList.Domain.Languages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Infrastructure.Database.Configurations;

internal sealed class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> entityTypeBuilder)
    {
        entityTypeBuilder.ToTable("Languages", "dbo");

        entityTypeBuilder.HasKey(entity => entity.Id);

        entityTypeBuilder.Property(entity => entity.Name)
            .HasColumnType("varchar(20)")
            .HasMaxLength(20)
            .IsRequired();
    }
}
