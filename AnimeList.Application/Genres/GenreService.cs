using AnimeList.Domain.Common;
using AnimeList.Domain.Genres;
using AnimeList.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Genres;

public class GenreService : IGenreService
{
    private readonly IUnitOfWork unitOfWork;

    public GenreService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Genre> Create(Genre newGenre)
    {
        await unitOfWork.Genres.CreateAsync(newGenre);
        await unitOfWork.SaveAsync();
        return newGenre;
    }

    public async Task Delete(int id)
    {
        await unitOfWork.Genres.DeleteAsync(id);
        await unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<Genre>> Get()
    {
        return await unitOfWork.Genres.GetAsync();
    }

    public async Task<Genre?> GetById(int id)
    {
        return await unitOfWork.Genres.GetByIdAsync(id);
    }

    public async Task<Genre> Update(Genre updatedGenre)
    {
        await unitOfWork.Genres.UpdateAsync(updatedGenre);
        await unitOfWork.SaveAsync();
        return updatedGenre;
    }
}
