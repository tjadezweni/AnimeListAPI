using AnimeList.Domain.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Languages;

public interface ILanguageService
{
    Task<Language?> GetById(int id);
    Task<IEnumerable<Language>> Get();
    Task<Language> Create(Language newStudio);
    Task<Language> Update(Language updatedStudio);
    Task Delete(int id);
}
