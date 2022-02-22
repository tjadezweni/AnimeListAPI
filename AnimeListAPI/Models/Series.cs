using System.ComponentModel.DataAnnotations;

namespace AnimeListAPI.Models;

public class Series
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Desciption { get; set; } = null!;

    public int Seasons { get; set; }

    public int Episodes { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime YearStarted { get; set; }

    public DateTime YearEnded { get; set; }

    public Genre Genre { get; set; } = null!;

    public Studio Studio { get; set; } = null!;
}
