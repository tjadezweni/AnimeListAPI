using AnimeListAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Queries.GetStudioById;

public class GetStudioByIdQuery : IRequest<Studio?>
{
    public int Id { get; set; }
}
