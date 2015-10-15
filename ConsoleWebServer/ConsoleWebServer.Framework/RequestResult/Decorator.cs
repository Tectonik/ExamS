namespace ConsoleWebServer.Framework.ActionResult
{
    using System;
    using System.Linq;
    using ConsoleWebServer.Framework;
    using ConsoleWebServer.Framework.Interfaces;
    using ConsoleWebServer.Framework.RequestResult;

    public abstract class Decorator : HttpRequestResult
    {
        public Decorator(IRequestResult result, HttpRequest request, object model) : base(request, model)
        {
            this.RequestResult = result;
        }

        protected IRequestResult RequestResult { get; set; }
    }
}