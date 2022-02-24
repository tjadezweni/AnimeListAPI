using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Domain.Helpers;

public class ErrorMessages
{
    public static string IdNotFound(ModelType modelType) => $"Id provided for {modelType.ToString()} does not exist";

    public static string IdFound(ModelType modelType) => $"Id provided for {modelType.ToString()} already exists";

    public static string IdMismatch() => $"Id provided does not match Id within request object";
}
