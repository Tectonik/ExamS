namespace ConsoleWebServer.Framework.ActionResult
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class HttpRequestResult
    {
        protected readonly object model;

        public HttpRequestResult(HttpRequest request, object model)
        {
            this.model = model;
            this.Request = request;
            this.ResponseHeaders = new Dictionary<string, string>();
        }

        public HttpRequest Request { get; private set; }

        public Dictionary<string, string> ResponseHeaders { get; private set; }
    }
}