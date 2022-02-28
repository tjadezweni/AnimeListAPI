﻿using AnimeList.Application.Studios.Queries;
using AnimeList.Domain.Common;
using AnimeList.Domain.Studios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Studios.Handlers;

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
        var studio = await _unitOfWork.Studios.GetByIdAsync(id);
        return studio;
    }
}
