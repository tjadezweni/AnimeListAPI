using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Queries.GetAllStudios;

public class GetAllStudiosQueryHandler : IRequestHandler<GetAllStudiosQuery, List<Studio>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllStudiosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Studio>> Handle(GetAllStudiosQuery request, CancellationToken cancellationToken)
    {
        var studiosList = await _unitOfWork._studioRepository.ListAsync(studio => true);
        return studiosList;
    }
}
