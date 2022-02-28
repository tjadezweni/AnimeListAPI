using AnimeList.Domain.Genres;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Genres.Queries;

public class GetAllGenresQuery : IRequest<IEnumerable<Genre>>
{

}
