using AnimeListAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.UpdateGenre;

public class UpdateGenreCommand : IRequest<Genre>
{
    public Genre Genre { get; set; }
}
