using AnimeList.Application.Serieses.Commands;
using AnimeList.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Serieses.Handlers;

public class DeleteSeriesCommandHandler : IRequestHandler<DeleteSeriesCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSeriesCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(DeleteSeriesCommand request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        await _unitOfWork.Series.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return id;
    }
}
