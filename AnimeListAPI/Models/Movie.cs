using System.ComponentModel.DataAnnotations;

namespace AnimeListAPI.Models;

public class Movie
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime YearReleased { get; set; }

    public Genre Genre { get; set; } = null!;

    public Studio Studio { get; set; } = null!;
}
