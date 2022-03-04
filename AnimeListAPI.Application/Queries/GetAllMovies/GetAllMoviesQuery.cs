﻿using AnimeListAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Queries.GetAllMovies;

public class GetAllMoviesQuery : IRequest<List<Movie>>
{
}
