using System.ComponentModel.DataAnnotations;

namespace AnimeListAPI.Dto;

public class StudioDTO
{
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(20)]
    public string Name { get; set; } = null!;
}
