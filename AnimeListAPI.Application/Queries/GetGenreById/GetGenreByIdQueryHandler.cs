using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Queries.GetGenreById;

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
        var genre = await _unitOfWork._genreRepository.GetAsync(genre => genre.GenreId == id);
        return genre;
    }
}
