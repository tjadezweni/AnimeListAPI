using System.ComponentModel.DataAnnotations;

namespace AnimeListAPI.Dto;

public class MovieDTO
{
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(20)]
    public string Title { get; set; } = null!;

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime YearReleased { get; set; }

    public GenreDTO Genre { get; set; } = null!;

    public StudioDTO Studio { get; set; } = null!;
}
