﻿using AnimeList.Domain.Movies;
using AnimeList.Domain.Serieses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnimeList.Domain.Studios;

public class Studio
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}