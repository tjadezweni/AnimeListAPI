using AnimeList.Domain.Common;
using AnimeList.Domain.Helpers;
using AnimeList.Domain.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Languages;

public class LanguageService : ILanguageService
{
    private readonly IUnitOfWork unitOfWork;

    public LanguageService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Language> Create(Language newStudio)
    {
        var existingLanguage = await unitOfWork.Studio.GetByIdAsync(newStudio.Id);
        if (existingLanguage is not null)
        {
            throw new Exception(ErrorMessages.IdFound(ModelType.Studio));
        }
        var language = new Language()
        {
            Id = newStudio.Id,
            Name = newStudio.Name
        };
        await unitOfWork.Languages.CreateAsync(language);
        await unitOfWork.SaveAsync();
        return language;
    }

    public async Task Delete(int id)
    {
        await unitOfWork.Languages.DeleteAsync(id);
        await unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<Language>> Get()
    {
        return await unitOfWork.Languages.GetAsync();
    }

    public async Task<Language?> GetById(int id)
    {
        return await unitOfWork.Languages.GetByIdAsync(id);
    }

    public async Task<Language> Update(Language updatedLanguage)
    {
        await unitOfWork.Languages.UpdateAsync(updatedLanguage);
        await unitOfWork.SaveAsync();
        return updatedLanguage;
    }
}
