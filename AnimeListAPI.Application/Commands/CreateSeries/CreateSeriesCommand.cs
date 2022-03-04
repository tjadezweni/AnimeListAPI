using AnimeListAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.CreateSeries;

public class CreateSeriesCommand : IRequest<Series>
{
    public Series Series { get; set; }
}
