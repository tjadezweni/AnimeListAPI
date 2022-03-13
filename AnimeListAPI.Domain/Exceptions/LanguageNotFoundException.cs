using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Domain.Exceptions;

public class LanguageNotFoundException : ApiException
{
    public LanguageNotFoundException()
        : base("The language with the provided Id was not found") { }
}
