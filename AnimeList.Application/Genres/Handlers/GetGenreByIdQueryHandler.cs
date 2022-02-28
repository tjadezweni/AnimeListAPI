using AnimeList.Application.Genres.Queries;
using AnimeList.Domain.Common;
using AnimeList.Domain.Genres;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Genres.Handlers;

public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, Genre?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetGenreByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Genre?> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        var genre = await _unitOfWork.Genres.GetByIdAsync(id);
        return genre;
    }
}
