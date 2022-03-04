using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Domain.Exceptions;

public class CountryNotFoundException : ApiException
{
    public CountryNotFoundException()
        : base("The country with the provided Id was not found") { }
}
