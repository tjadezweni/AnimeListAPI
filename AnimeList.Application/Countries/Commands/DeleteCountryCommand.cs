using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Countries.Commands;

public class DeleteCountryCommand : IRequest<int>
{
    public int Id { get; }

    public DeleteCountryCommand(int id)
    {
        Id = id;
    }
}
