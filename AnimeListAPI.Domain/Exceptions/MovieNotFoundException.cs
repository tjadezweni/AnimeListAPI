using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Domain.Exceptions;

public class MovieNotFoundException : ApiException
{
    public MovieNotFoundException()
        : base("The movie with the provided Id was not found") { }
}
