using AnimeList.Domain.Movies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Movies.Queries;

public class GetMovieByIdQuery : IRequest<Movie?>
{
    public int Id { get; }

    public GetMovieByIdQuery(int id)
    {
        Id = id;
    }
}
