using AnimeListAPI.Domain.Exceptions;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.DeleteLanguage;

public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteLanguageCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        var language = await _unitOfWork._languageRepository.GetAsync(language => language.LanguageId == id);
        if (language is null)
        {
            throw new LanguageNotFoundException();
        }
        await _unitOfWork._languageRepository.DeleteAsync(language);
        await _unitOfWork.SaveAsync();
        return id;
    }
}
