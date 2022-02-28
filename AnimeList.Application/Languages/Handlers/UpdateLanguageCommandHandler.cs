using AnimeList.Application.Languages.Commands;
using AnimeList.Domain.Common;
using AnimeList.Domain.Helpers;
using AnimeList.Domain.Languages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Languages.Handlers;

public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, Language>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateLanguageCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Language> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
    {
        var existingLanguage = await _unitOfWork.Languages.GetByIdAsync(request.Id);
        if (existingLanguage is null)
        {
            throw new ApiException(ErrorMessages.IdNotFound(ModelType.Country));
        }
        existingLanguage.Name = request.Name;
        await _unitOfWork.Languages.UpdateAsync(existingLanguage);
        await _unitOfWork.SaveAsync();
        return existingLanguage;
    }
}
