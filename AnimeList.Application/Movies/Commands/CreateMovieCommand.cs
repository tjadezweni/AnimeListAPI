using AnimeList.Domain.Movies;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Movies.Commands;

public class CreateMovieCommand : IRequest<Movie>
{
    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public DateTime YearReleased { get; set; }

    [Required]
    public int GenreId { get; set; }

    [Required]
    public int StudioId { get; set; }

    [Required]
    public int LanguageId { get; set; }
    
    [Required]
    public int CountryId { get; set; }
}
