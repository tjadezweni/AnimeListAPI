using AnimeList.Application.Countries.Commands;
using AnimeList.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Countries.Handlers;

public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCountryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        await _unitOfWork.Countries.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return id;
    }
}
