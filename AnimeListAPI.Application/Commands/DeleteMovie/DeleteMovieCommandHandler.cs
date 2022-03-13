using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.DeleteMovie;

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
        var movie = await _unitOfWork._movieRepository.GetAsync(movie => movie.MovieId == id);
        await _unitOfWork._movieRepository.DeleteAsync(movie);
        await _unitOfWork.SaveAsync();
        return id;
    }
}
