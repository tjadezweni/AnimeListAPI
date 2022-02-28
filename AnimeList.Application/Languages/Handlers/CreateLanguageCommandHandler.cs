using AnimeList.Application.Languages.Commands;
using AnimeList.Domain.Common;
using AnimeList.Domain.Languages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Languages.Handlers;

public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, Language>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateLanguageCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Language> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
    {
        var name = request.Name;
        var newLanguage = new Language(name);
        await _unitOfWork.Languages.CreateAsync(newLanguage);
        await _unitOfWork.SaveAsync();
        return newLanguage;
    }
}
