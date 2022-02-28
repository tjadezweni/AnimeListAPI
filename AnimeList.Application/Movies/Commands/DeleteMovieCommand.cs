using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Movies.Commands;

public class DeleteMovieCommand : IRequest<int>
{
    public int Id { get; }

    public DeleteMovieCommand(int id)
    {
        Id = id;
    }
}
