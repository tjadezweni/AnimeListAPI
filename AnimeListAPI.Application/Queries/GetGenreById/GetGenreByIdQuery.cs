﻿using AnimeListAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Queries.GetGenreById;

public class GetGenreByIdQuery : IRequest<Genre?>
{
    public int Id { get; set; }
}
