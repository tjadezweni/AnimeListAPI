using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Queries.GetStudioById;

public class GetStudioByIdQueryHandler : IRequestHandler<GetStudioByIdQuery, Studio?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetStudioByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Studio?> Handle(GetStudioByIdQuery request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        var studio = await _unitOfWork._studioRepository.GetAsync(studio => studio.StudioId == id);
        return studio;
    }
}
