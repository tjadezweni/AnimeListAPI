using AnimeList.Domain.Serieses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Serieses.Commands;

public class UpdateSeriesCommand : IRequest<Series>
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public int Seasons { get; set; }

    [Required]
    public int Episodes { get; set; }

    [Required]
    public bool IsCompleted { get; set; }

    [Required]
    public DateTime YearStarted { get; set; }

    [Required]
    public DateTime YearEnded { get; set; }

    [Required]
    public int GenreId { get; set; }

    [Required]
    public int StudioId { get; set; }

    [Required]
    public int LanguageId { get; set; }

    [Required]
    public int CountryId { get; set; }
}
