namespace ConsoleWebServer.Framework.RequestResult
{
    using System;
    using System.Linq;
    using System.Net;
    using ConsoleWebServer.Framework;
    using ConsoleWebServer.Framework.ActionResult;

    internal class ResultWithoutCaching : Decorator
    {
        public ResultWithoutCaching(HttpRequestResult jsonResult, HttpRequest request, object model) : base(jsonResult, request, model)
        {
            this.RequestResult.AddHeader("Cache-Control", "private, max-age=0, no-cache");
        }

        public override HttpStatusCode GetStatusCode()
        {
            return this.RequestResult.GetStatusCode();
        }

        public override string GetContent()
        {
            return this.RequestResult.GetContent();
        }

        public override HttpResponse GetResponse()
        {
            return this.RequestResult.GetResponse();
        }
    }
}