namespace ConsoleWebServer.Framework.ActionResult
{
    using System;
    using System.Linq;
    using ConsoleWebServer.Framework;

    internal class DecoratorResultWithCors : Decorator
    {
        public DecoratorResultWithCors(HttpRequestResult jsonResult, HttpRequest request, object model, string corsSettings) : base(jsonResult, request, model)
        {
            this.requestResult.ResponseHeaders.Add("Access-Control-Allow-Origin", corsSettings);
        }
    }
}