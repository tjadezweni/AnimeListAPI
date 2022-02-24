using AnimeList.Domain.Studios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Studios;

public interface IStudioService
{
    Task<Studio?> GetById(int id);
    Task<IEnumerable<Studio>> Get();
    Task<Studio> Create(Studio newStudio);
    Task<Studio> Update(Studio updatedStudio);
    Task Delete(int id);
}
