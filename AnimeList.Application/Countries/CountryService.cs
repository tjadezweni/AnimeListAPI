using AnimeList.Domain.Common;
using AnimeList.Domain.Countries;
using AnimeList.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Countries;

public class CountryService : ICountryService
{
    private readonly IUnitOfWork unitOfWork;

    public CountryService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Country> Create(Country newCountry)
    {
        var existingCountry = await unitOfWork.Countries.GetByIdAsync(newCountry.Id);
        if (existingCountry is not null)
        {
            throw new ApiException(ErrorMessages.IdFound(ModelType.Country));
        }
        var country = new Country()
        {
            Id = newCountry.Id,
            Name = newCountry.Name,
        };
        await unitOfWork.Countries.CreateAsync(country);
        await unitOfWork.SaveAsync();
        return country;
    }

    public async Task Delete(int id)
    {
        await unitOfWork.Countries.DeleteAsync(id);
        await unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<Country>> Get()
    {
        return await unitOfWork.Countries.GetAsync();
    }

    public async Task<Country?> GetById(int id)
    {
        return await unitOfWork.Countries.GetByIdAsync(id);
    }

    public async Task<Country> Update(Country updatedCountry)
    {
        await unitOfWork.Countries.UpdateAsync(updatedCountry);
        await unitOfWork.SaveAsync();
        return updatedCountry;
    }
}
