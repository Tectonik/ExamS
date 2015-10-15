namespace ConsoleWebServer.Framework
{
    using System;
    using System.Linq;

    public class HttpResourceNotFoundException : Exception
    {
        public const string ClassName = "HttpNotFoundException";

        public HttpResourceNotFoundException(string message) : base(message)
        {
        }
    }
}