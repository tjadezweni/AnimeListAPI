using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Languages.Commands;

public class DeleteLanguageCommand : IRequest<int>
{
    public int Id { get; }

    public DeleteLanguageCommand(int id)
    {
        Id = id;
    }
}
