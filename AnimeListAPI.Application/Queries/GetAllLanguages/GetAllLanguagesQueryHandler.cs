using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Queries.GetAllLanguages;

public class GetAllLanguagesQueryHandler : IRequestHandler<GetAllLanguagesQuery, List<Language>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllLanguagesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Language>> Handle(GetAllLanguagesQuery request, CancellationToken cancellationToken)
    {
        var languagesList = await _unitOfWork._languageRepository.ListAsync(language => true);
        return languagesList;
    }
}
