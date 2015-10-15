namespace ConsoleWebServer.Framework
{
    /// <summary>
    /// Interface for classes that receive responces from remote sources and process requests in string format
    /// </summary>
    public interface IResponseProvider
    {
        HttpResponse GetResponse(string requestAsString);
    }
}