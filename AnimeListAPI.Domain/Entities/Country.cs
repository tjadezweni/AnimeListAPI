using AnimeListAPI.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Domain.Entities;

public record Country : BaseEntity
{
    public int CountryId { get; set; }

    public string Name { get; set; } = null!;
}
