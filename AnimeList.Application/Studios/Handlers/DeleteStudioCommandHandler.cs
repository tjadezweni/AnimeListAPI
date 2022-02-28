using AnimeList.Application.Studios.Commands;
using AnimeList.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Studios.Handlers;

public class DeleteStudioCommandHandler : IRequestHandler<DeleteStudioCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStudioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(DeleteStudioCommand request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        await _unitOfWork.Studios.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return id;
    }
}
