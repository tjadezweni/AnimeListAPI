using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Genres.Commands;

public class DeleteGenreCommand : IRequest<int>
{
    public int Id { get; }

    public DeleteGenreCommand(int id)
    {
        Id = id;
    }
}
