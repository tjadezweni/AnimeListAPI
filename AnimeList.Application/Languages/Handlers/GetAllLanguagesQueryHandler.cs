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

public class GetAllLanguagesQueryHandler : IRequestHandler<GetAllLanguagesQuery, IEnumerable<Language>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllLanguagesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Language>> Handle(GetAllLanguagesQuery request, CancellationToken cancellationToken)
    {
        var languagesList = await _unitOfWork.Languages.GetAsync();
        return languagesList;
    }
}
