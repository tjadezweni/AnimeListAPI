using AnimeListAPI.Domain.Exceptions;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.DeleteStudio;

public class DeleteStudioCommandHandler : IRequestHandler<DeleteStudioCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStudioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(DeleteStudioCommand request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        var existingStudio = await _unitOfWork._studioRepository.GetAsync(studio => studio.StudioId == id);
        if (existingStudio is null)
        {
            throw new StudioNotFoundException();
        }
        await _unitOfWork._studioRepository.DeleteAsync(existingStudio);
        await _unitOfWork.SaveAsync();
        return id;
    }
}
