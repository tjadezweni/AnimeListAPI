using AnimeListAPI.Domain.Entities;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.CreateLanguage;

public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, Language>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateLanguageCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Language> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
    {
        var newLanguage = request.Language;
        await _unitOfWork._languageRepository.AddAsync(newLanguage);
        await _unitOfWork.SaveAsync();
        return newLanguage;
    }
}
