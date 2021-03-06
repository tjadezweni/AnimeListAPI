using AnimeListAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Application.Commands.UpdateMovie;

public class UpdateMovieCommand : IRequest<Movie>
{
    public Movie Movie { get; set; }
}
