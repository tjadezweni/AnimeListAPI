using AnimeList.Domain.Languages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Languages.Queries;

public class GetLanguageByIdQuery : IRequest<Language?>
{
    public int Id { get; }

    public GetLanguageByIdQuery(int id)
    {
        Id = id;
    }
}
