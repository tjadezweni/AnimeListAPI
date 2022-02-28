using AnimeList.Application.Languages.Commands;
using AnimeList.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Languages.Handlers;

public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteLanguageCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        await _unitOfWork.Languages.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return id;
    }
}
