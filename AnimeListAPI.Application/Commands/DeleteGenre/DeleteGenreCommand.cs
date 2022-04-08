using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.DeleteGenre;

public class DeleteGenreCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
