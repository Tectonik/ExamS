namespace ConsoleWebServer.Framework.Json
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ConsoleWebServer.Framework.Interfaces;

    class ResultWithoutCaching : Decorator
    {
        public ResultWithoutCaching(JsonResult jsonResult, HttpRequest request, object model, string corsSettings)
            : base(jsonResult, request, model)
        {
            this.JsonResult.ResponseHeaders.Add("Cache-Control", "private, max-age=0, no-cache");
        }
    }
}
