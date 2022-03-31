using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Infrastructure;

public class AnimeListAPIContext : DbContext
{
    #region Tables
    public DbSet<Country> Countries { get; set; } = null!;

    public DbSet<Genre> Genres { get; set; } = null!;

    public DbSet<Language> Languages { get; set; } = null!;

    public DbSet<Movie> Movies { get; set; } = null!;

    public DbSet<Series> Series { get; set; } = null!;

    public DbSet<Studio> Studios { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;
    #endregion

    public AnimeListAPIContext(DbContextOptions<AnimeListAPIContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CountryConfiguration).Assembly);
    }
}
