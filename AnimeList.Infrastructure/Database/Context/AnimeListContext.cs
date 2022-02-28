using AnimeList.Domain.Countries;
using AnimeList.Domain.Genres;
using AnimeList.Domain.Languages;
using AnimeList.Domain.Movies;
using AnimeList.Domain.Serieses;
using AnimeList.Domain.Studios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Infrastructure.Database.Context;

public class AnimeListContext : DbContext
{
    #region Tables
    public DbSet<Country> Countries { get; set; } = null!;

    public DbSet<Genre> Genres { get; set; } = null!;

    public DbSet<Language> Languages { get; set; } = null!;

    public DbSet<Movie> Movies { get; set; } = null!;

    public DbSet<Series> Series { get; set; } = null!;

    public DbSet<Studio> Studios { get; set; } = null!;
    #endregion

    public AnimeListContext(DbContextOptions<AnimeListContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
