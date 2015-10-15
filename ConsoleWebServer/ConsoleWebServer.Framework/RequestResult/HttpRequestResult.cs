namespace ConsoleWebServer.Framework.RequestResult
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using ConsoleWebServer.Framework;
    using ConsoleWebServer.Framework.Interfaces;

    public abstract class HttpRequestResult : IRequestResult
    {
        protected readonly object Model;

        public HttpRequestResult(HttpRequest request, object model)
        {
            this.Model = model;
            this.Request = request;
            this.ResponseHeaders = new Dictionary<string, string>();
        }

        public HttpRequest Request { get; private set; }

        public Dictionary<string, string> ResponseHeaders { get; private set; }

        public abstract HttpStatusCode GetStatusCode();

        public abstract string GetContent();

        public abstract HttpResponse GetResponse();

        public void AddHeader(string key, string value)
        {
            this.ResponseHeaders.Add(key, value);
        }
    }
}