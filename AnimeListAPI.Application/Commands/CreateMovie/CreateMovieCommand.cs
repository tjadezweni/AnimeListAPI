using AnimeListAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.CreateMovie;

public class CreateMovieCommand : IRequest<Movie>
{
    public Movie Movie { get; set; }
}
