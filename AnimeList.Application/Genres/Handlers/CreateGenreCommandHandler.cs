using AnimeList.Application.Genres.Commands;
using AnimeList.Domain.Common;
using AnimeList.Domain.Genres;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Genres.Handlers;

public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, Genre>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateGenreCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Genre> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        var newGenre = new Genre(request.Name, request.Description);
        await _unitOfWork.Genres.CreateAsync(newGenre);
        await _unitOfWork.SaveAsync();
        return newGenre;
    }
}
