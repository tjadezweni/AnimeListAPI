using AnimeListAPI.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Domain.Entities;

public record Movie : BaseEntity
{
    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime YearReleased { get; set; }

    [ForeignKey("GenreId")]
    public int GenreId { get; set; }

    public Genre? Genre { get; set; }

    [ForeignKey("StudioId")]
    public int StudioId { get; set; }

    public Studio? Studio { get; set; }

    [ForeignKey("LanguageId")]
    public int LanguageId { get; set; }

    public Language? Language { get; set; }

    [ForeignKey("CountryId")]
    public int CountryId { get; set; }

    public Country? Country { get; set; }

}
