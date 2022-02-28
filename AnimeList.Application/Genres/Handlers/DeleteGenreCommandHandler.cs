using AnimeList.Application.Genres.Commands;
using AnimeList.Domain.Common;
using AnimeList.Domain.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Genres.Handlers;

public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteGenreCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        await _unitOfWork.Genres.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return id;
    }
}
