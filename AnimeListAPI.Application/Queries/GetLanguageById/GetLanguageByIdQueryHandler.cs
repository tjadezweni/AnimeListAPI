using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Queries.GetLanguageById;

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
        var language = await _unitOfWork._languageRepository.GetAsync(language => language.LanguageId == id);
        return language;
    }
}
