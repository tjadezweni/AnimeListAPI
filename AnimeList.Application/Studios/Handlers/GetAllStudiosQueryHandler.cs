using AnimeList.Application.Studios.Queries;
using AnimeList.Domain.Common;
using AnimeList.Domain.Studios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Studios.Handlers;

public class GetAllStudiosQueryHandler : IRequestHandler<GetAllStudiosQuery, IEnumerable<Studio>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllStudiosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Studio>> Handle(GetAllStudiosQuery request, CancellationToken cancellationToken)
    {
        var studiosList = await _unitOfWork.Studios.GetAsync();
        return studiosList;
    }
}
