namespace ConsoleWebServer.Framework.Interfaces
{
    using System;
    using System.Linq;
    using System.Net;

    public interface IRequestResult
    {
        HttpStatusCode GetStatusCode();

        string GetContent();

        HttpResponse GetResponse();

        void AddHeader(string key, string value);
    }
}