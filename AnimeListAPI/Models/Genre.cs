using System.ComponentModel.DataAnnotations;

namespace AnimeListAPI.Models;

public class Genre
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
}
