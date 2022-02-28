using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Serieses.Commands;

public class DeleteSeriesCommand : IRequest<int>
{
    public int Id { get; set; }

    public DeleteSeriesCommand(int id)
    {
        Id = id;
    }
}
