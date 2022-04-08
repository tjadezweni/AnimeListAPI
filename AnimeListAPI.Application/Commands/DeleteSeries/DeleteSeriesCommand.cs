using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.DeleteSeries;

public class DeleteSeriesCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
