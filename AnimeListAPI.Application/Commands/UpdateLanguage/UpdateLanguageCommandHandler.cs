using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.Exceptions;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.UpdateLanguage;

public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, Language>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateLanguageCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Language> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
    {
        var id = request.Language.LanguageId;
        var existingLanguage = await _unitOfWork._languageRepository.GetAsync(language => language.LanguageId == id);
        if (existingLanguage is null)
        {
            throw new LanguageNotFoundException();
        }
        var language = request.Language;
        existingLanguage.Name = language.Name;
        await _unitOfWork._languageRepository.UpdateAsync(existingLanguage);
        await _unitOfWork.SaveAsync();
        return existingLanguage;
    }
}
