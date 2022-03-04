using AnimeListAPI.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnimeListAPI.Domain.Entities;

public record Studio : BaseEntity
{
    public int StudioId { get; set; }

    public string Name { get; set; }
}