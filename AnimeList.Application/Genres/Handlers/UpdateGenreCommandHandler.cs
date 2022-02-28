using AnimeList.Application.Genres.Commands;
using AnimeList.Domain.Common;
using AnimeList.Domain.Genres;
using AnimeList.Domain.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Genres.Handlers;

public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, Genre>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public UpdateGenreCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Genre> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        var existingGenre = await _unitOfWork.Genres.GetByIdAsync(request.Id);
        if (existingGenre is null)
        {
            throw new ApiException(ErrorMessages.IdNotFound(ModelType.Genre));
        }
        existingGenre.Name = request.Name;
        existingGenre.Description = request.Description;
        await _unitOfWork.Genres.UpdateAsync(existingGenre);
        await _unitOfWork.SaveAsync();
        return existingGenre;
    }
}
