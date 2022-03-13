using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.CreateStudio;

public class CreateStudioCommandHandler : IRequestHandler<CreateStudioCommand, Studio>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateStudioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Studio> Handle(CreateStudioCommand request, CancellationToken cancellationToken)
    {
        var newStudio = request.Studio;
        await _unitOfWork._studioRepository.AddAsync(newStudio);
        await _unitOfWork.SaveAsync();
        return newStudio;
    }
}
