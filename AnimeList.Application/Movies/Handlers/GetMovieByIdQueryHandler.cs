using AnimeList.Application.Movies.Queries;
using AnimeList.Domain.Common;
using AnimeList.Domain.Movies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Movies.Handlers;

public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, Movie?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMovieByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Movie?> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        var movie = await _unitOfWork.Movies.GetByIdAsync(id);
        return movie;
    }
}