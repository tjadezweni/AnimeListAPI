using AnimeList.Application.Languages.Queries;
using AnimeList.Domain.Common;
using AnimeList.Domain.Languages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Languages.Handlers;

public class GetLanguageByIdQueryHandler : IRequestHandler<GetLanguageByIdQuery, Language?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetLanguageByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Language?> Handle(GetLanguageByIdQuery request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        var language = await _unitOfWork.Languages.GetByIdAsync(id);
        return language;
    }
}
