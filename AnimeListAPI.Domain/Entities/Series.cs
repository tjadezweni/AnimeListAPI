using AnimeListAPI.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Domain.Entities;

public record Series : BaseEntity
{
    public int SeriesId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Seasons { get; set; }

    public int Episodes { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime YearStarted { get; set; }

    public DateTime YearEnded { get; set; }

    [ForeignKey("GenreId")]
    public int GenreId { get; set; }

    public Genre? Genre { get; set; } = null!;

    [ForeignKey("StudioId")]
    public int StudioId { get; set; }

    public Studio? Studio { get; set; } = null!;

    [ForeignKey("LanguageId")]
    public int LanguageId { get; set; }

    public Language? Language { get; set; } = null!;

    [ForeignKey("CountryId")]
    public int CountryId { get; set; }

    public Country? Country { get; set; } = null!;

}
