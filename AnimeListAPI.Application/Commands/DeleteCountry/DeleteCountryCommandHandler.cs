using AnimeListAPI.Domain.Exceptions;
using AnimeListAPI.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.DeleteCountry;

public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCountryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        var country = await _unitOfWork._countryRepository.GetAsync(country => country.CountryId == id);
        if (country is null)
        {
            throw new CountryNotFoundException();
        }
        await _unitOfWork._countryRepository.DeleteAsync(country);
        await _unitOfWork.SaveAsync();
        return Unit.Value;
    }
}
