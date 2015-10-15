namespace ConsoleWebServer.Framework.ActionResult
{
    using System;
    using System.Linq;
    using ConsoleWebServer.Framework;

    public abstract class Decorator : HttpRequestResult
    {
        public Decorator(HttpRequestResult result, HttpRequest request, object model) : base(request, model)
        {
            this.requestResult = result;
        }

        protected HttpRequestResult requestResult { get; set; }
    }
}