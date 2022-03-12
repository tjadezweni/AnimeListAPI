using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.Exceptions;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.UpdateStudio;

public class UpdateStudioCommandHandler : IRequestHandler<UpdateStudioCommand, Studio>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStudioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Studio> Handle(UpdateStudioCommand request, CancellationToken cancellationToken)
    {
        var id = request.Studio.StudioId;
        var existingStudio = await _unitOfWork._studioRepository.GetAsync(studio => studio.StudioId == id);
        if (existingStudio is null)
        {
            throw new StudioNotFoundException();
        }
        var studio = request.Studio;
        existingStudio.Name = studio.Name;
        await _unitOfWork._studioRepository.UpdateAsync(existingStudio);
        await _unitOfWork.SaveAsync();
        return existingStudio;
    }
}
