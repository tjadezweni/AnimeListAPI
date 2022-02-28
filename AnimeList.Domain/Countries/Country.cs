using AnimeList.Domain.Common;
using AnimeList.Domain.Movies;
using AnimeList.Domain.Serieses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnimeList.Domain.Countries;

public class Country : BaseEntity
{
    public string Name { get; set; } = null!;

    [JsonIgnore]
    public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();

    [JsonIgnore]
    public ICollection<Series> Series { get; set; } = new HashSet<Series>();

    public Country(string name)
    {
        Name = name;
    }
}
