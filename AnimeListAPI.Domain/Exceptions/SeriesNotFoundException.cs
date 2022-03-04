using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Domain.Exceptions;

public class SeriesNotFoundException : ApiException
{
    public SeriesNotFoundException()
        : base("The series with the provided Id was not found") { }
}
