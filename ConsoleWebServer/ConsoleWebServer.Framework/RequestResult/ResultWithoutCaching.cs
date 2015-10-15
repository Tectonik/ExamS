namespace ConsoleWebServer.Framework.ActionResult
{
    using System;
    using System.Linq;
    using ConsoleWebServer.Framework;

    internal class ResultWithoutCaching : Decorator
    {
        public ResultWithoutCaching(HttpRequestResult jsonResult, HttpRequest request, object model, string corsSettings) : base(jsonResult, request, model)
        {
            this.requestResult.ResponseHeaders.Add("Cache-Control", "private, max-age=0, no-cache");
        }
    }
}