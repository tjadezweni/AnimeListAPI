using AnimeList.Application.Countries.Commands;
using AnimeList.Domain.Common;
using AnimeList.Domain.Countries;
using AnimeList.Domain.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Countries.Handlers;

public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Country>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCountryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Country> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var existingCountry = await _unitOfWork.Countries.GetByIdAsync(request.Id);
        if (existingCountry is null)
        {
            throw new ApiException(ErrorMessages.IdNotFound(ModelType.Country));
        }
        existingCountry.Name = request.Name;
        await _unitOfWork.Countries.UpdateAsync(existingCountry);
        await _unitOfWork.SaveAsync();
        return existingCountry;
    }
}
