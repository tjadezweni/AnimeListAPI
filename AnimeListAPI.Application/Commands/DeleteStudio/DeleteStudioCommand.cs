using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.DeleteStudio;

public class DeleteStudioCommand : IRequest<int>
{
    public int Id { get; set; }
}
