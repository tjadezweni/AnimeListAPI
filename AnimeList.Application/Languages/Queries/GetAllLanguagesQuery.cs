using AnimeList.Domain.Languages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Languages.Queries;

public class GetAllLanguagesQuery : IRequest<IEnumerable<Language>>
{

}
