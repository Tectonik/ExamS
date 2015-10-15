namespace ConsoleWebServer.Framework.Json
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ConsoleWebServer.Framework.Interfaces;

    class ResultWithCors : Decorator
    {
        public ResultWithCors(JsonResult jsonResult, HttpRequest request, object model, string corsSettings)
            : base(jsonResult, request, model)
        {
            this.JsonResult.ResponseHeaders.Add("Access-Control-Allow-Origin", corsSettings);
        }
    }
}
