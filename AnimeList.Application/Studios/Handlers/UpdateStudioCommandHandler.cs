using AnimeList.Application.Studios.Commands;
using AnimeList.Domain.Common;
using AnimeList.Domain.Helpers;
using AnimeList.Domain.Studios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Studios.Handlers;

public class UpdateStudioCommandHandler : IRequestHandler<UpdateStudioCommand, Studio>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStudioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Studio> Handle(UpdateStudioCommand request, CancellationToken cancellationToken)
    {
        var existingStudio = await _unitOfWork.Studios.GetByIdAsync(request.Id);
        if (existingStudio is null)
        {
            throw new ApiException(ErrorMessages.IdNotFound(ModelType.Country));
        }
        existingStudio.Name = request.Name;
        await _unitOfWork.Studios.UpdateAsync(existingStudio);
        await _unitOfWork.SaveAsync();
        return existingStudio;
    }
}
