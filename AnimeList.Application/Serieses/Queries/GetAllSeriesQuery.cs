﻿using AnimeList.Domain.Serieses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Serieses.Queries;

public class GetAllSeriesQuery : IRequest<IEnumerable<Series>>
{
}