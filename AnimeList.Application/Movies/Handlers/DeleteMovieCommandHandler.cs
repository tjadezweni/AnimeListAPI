using AnimeList.Application.Movies.Commands;
using AnimeList.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Movies.Handlers;

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMovieCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        await _unitOfWork.Movies.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return id;
    }
}
