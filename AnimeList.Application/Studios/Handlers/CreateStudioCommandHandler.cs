using AnimeList.Application.Studios.Commands;
using AnimeList.Domain.Common;
using AnimeList.Domain.Studios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Studios.Handlers;

public class CreateStudioCommandHandler : IRequestHandler<CreateStudioCommand, Studio>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateStudioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Studio> Handle(CreateStudioCommand request, CancellationToken cancellationToken)
    {
        var name = request.Name;
        var newStudio = new Studio(name);
        await _unitOfWork.Studios.CreateAsync(newStudio);
        await _unitOfWork.SaveAsync();
        return newStudio;
    }
}
