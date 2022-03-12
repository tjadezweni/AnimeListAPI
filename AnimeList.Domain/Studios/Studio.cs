﻿using AnimeList.Domain.Common;
using AnimeList.Domain.Movies;
using AnimeList.Domain.Serieses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnimeList.Domain.Studios;

public class Studio : BaseEntity
{
    public string Name { get; set; } = null!;

    [JsonIgnore]
    public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();

    [JsonIgnore]
    public ICollection<Series> Series { get; set; } = new HashSet<Series>();

    public Studio(string name)
    {
        Name = name;
    }
}