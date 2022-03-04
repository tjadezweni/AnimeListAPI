using AnimeListAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.CreateStudio;

public class CreateStudioCommand : IRequest<Studio>
{
    public Studio Studio { get; set; }
}
