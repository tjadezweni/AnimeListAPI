namespace AnimeListAPI.Utilities;

public class ErrorMessages
{
    public static string IdNotFound(string modelName) => $"Id for {modelName} does not exist";

    public static string IdFound(string modelName) => $"Id for {modelName} already exists";
}
