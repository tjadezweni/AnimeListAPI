using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.Exceptions;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.UpdateGenre;

public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, Genre>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateGenreCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Genre> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        var id = request.Genre.GenreId;
        var genre = request.Genre;
        var existingGenre = await _unitOfWork._genreRepository.GetAsync(genre => genre.GenreId == id);
        if (existingGenre is null)
        {
            throw new GenreNotFoundException();
        }
        await _unitOfWork._genreRepository.UpdateAsync(genre);
        await _unitOfWork.SaveAsync();
        return genre;
    }
}