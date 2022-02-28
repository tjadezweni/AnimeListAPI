using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Studios.Commands;

public class DeleteStudioCommand : IRequest<int>
{
    public int Id { get; }

    public DeleteStudioCommand(int id)
    {
        Id = id;
    }
}