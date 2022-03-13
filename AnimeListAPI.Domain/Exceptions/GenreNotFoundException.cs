using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Domain.Exceptions;

public class GenreNotFoundException : ApiException
{
    public GenreNotFoundException()
        : base("The genre with the provided Id was not found") { }
}
