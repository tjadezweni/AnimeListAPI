using AnimeListAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.UpdateCountry;

public class UpdateCountryCommand : IRequest<Country>
{
    public Country country { get; set; }
}
