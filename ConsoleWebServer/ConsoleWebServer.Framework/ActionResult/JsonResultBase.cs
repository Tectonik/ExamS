namespace ConsoleWebServer.Framework.Json
{
    using System;
    using ConsoleWebServer.Framework;
    using ConsoleWebServer.Framework.Interfaces;

    public class JsonResultBasic : JsonResult, IJsonResult, IResult
    {
        public JsonResultBasic(HttpRequest request, object model)
            : base(request, model)
        {
        }
    }
}