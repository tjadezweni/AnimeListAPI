using Microsoft.EntityFrameworkCore;

namespace AnimeListAPI.Models;

public class DataContext : DbContext
{
    #region Tables

    public DbSet<Genre> Genres { get; set; } = null!;

    public DbSet<Studio> Studios { get; set; } = null!;

    public DbSet<Series> Series { get; set; } = null!;

    public DbSet<Movie> Movies { get; set; } = null!;

    #endregion

    public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }
}
