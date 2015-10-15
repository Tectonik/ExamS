namespace ConsoleWebServer.Framework.Interfaces
{
    using System;
    using System.Linq;
    using System.Net;

    public interface IJsonResult : IResult
    {
        HttpStatusCode GetStatusCode();
        string GetContent();
    }
}
