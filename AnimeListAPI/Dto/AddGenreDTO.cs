using System.ComponentModel.DataAnnotations;

namespace AnimeListAPI.Dto;

public class AddGenreDTO
{
    [Required]
    public Guid GenreId { get; set; }
}
