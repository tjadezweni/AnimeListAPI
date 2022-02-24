using AnimeList.Domain.Genres;
using AnimeList.Domain.Studios;
using AnimeList.Domain.Languages;
using AnimeList.Domain.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Domain.Serieses;

public class Series
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Seasons { get; set; }

    public int Episodes { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime YearStarted { get; set; }

    public DateTime YearEnded { get; set; }

    public int GenreId { get; set; }

    public virtual Genre Genre { get; set; } = null!;

    public int StudioId { get; set; }

    public virtual Studio Studio { get; set; } = null!;

    public int LanguageId { get; set; }

    public virtual Language Language { get; set; } = null!;

    public int CountryId { get; set; }

    public virtual Country Country { get; set; } = null!;
}
