﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Domain.SeedWork;

public record BaseEntity
{
    public bool IsDeleted { get; set; } = false;
}
