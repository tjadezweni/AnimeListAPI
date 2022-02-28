using AnimeList.Domain.Countries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Application.Countries.Queries;

public class GetAllCountriesQuery : IRequest<IEnumerable<Country>>
{

}
