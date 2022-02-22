using System.ComponentModel.DataAnnotations;

namespace AnimeListAPI.Dto;

public class SeriesDTO
{
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(20)]
    public string Title { get; set; } = null!;

    [MaxLength(35)]
    public string Desciption { get; set; } = null!;

    [Required]
    public int Seasons { get; set; }

    [Required]
    public int Episodes { get; set; }

    [Required]
    public bool IsCompleted { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime YearStarted { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime YearEnded { get; set; }

    public GenreDTO Genre { get; set; } = null!;

    public StudioDTO Studio { get; set; } = null!;
}
