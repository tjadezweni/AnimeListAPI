using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAPI.Domain.Exceptions;

public class StudioNotFoundException : ApiException
{
    public StudioNotFoundException()
        : base("The studio with the provided Id was not found") { }
}
