using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.DeleteCountry;

public class DeleteCountryCommand : IRequest<int>
{
    public int Id { get; set; }
}
