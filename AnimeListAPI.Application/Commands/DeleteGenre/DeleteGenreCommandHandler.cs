using AnimeListAPI.Domain.Exceptions;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.DeleteGenre;

public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteGenreCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        var genre = await _unitOfWork._genreRepository.GetAsync(genre => genre.GenreId == id);
        if (genre is null)
        {
            throw new GenreNotFoundException();
        }
        await _unitOfWork._genreRepository.DeleteAsync(genre);
        await _unitOfWork.SaveAsync();
        return Unit.Value;
    }
}