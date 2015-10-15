namespace ConsoleWebServer.Framework.RequestResult
{
    using System;
    using System.Linq;
    using System.Net;
    using ConsoleWebServer.Framework;
    using ConsoleWebServer.Framework.ActionResult;
    using ConsoleWebServer.Framework.Interfaces;

    internal class DecoratorResultWithCors : Decorator
    {
        public DecoratorResultWithCors(IRequestResult jsonResult, HttpRequest request, object model, string corsSettings) : base(jsonResult, request, model)
        {
            this.RequestResult.AddHeader("Access-Control-Allow-Origin", corsSettings);
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