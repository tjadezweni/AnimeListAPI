using System.ComponentModel.DataAnnotations;

namespace AnimeListAPI.Dto;

public class AddStudioDTO
{
    [Required]
    public Guid StudioId { get; set; }
}
