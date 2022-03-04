using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.CreateGenre;

public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, Genre>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateGenreCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Genre> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        var newGenre = request.Genre;
        await _unitOfWork._genreRepository.AddAsync(newGenre);
        await _unitOfWork.SaveAsync();
        return newGenre;
    }
}