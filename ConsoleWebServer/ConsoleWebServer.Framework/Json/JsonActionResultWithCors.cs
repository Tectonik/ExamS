namespace ConsoleWebServer.Framework
{
    using System.Collections.Generic;
    using ConsoleWebServer.Framework.Json;

    public class JsonActionResultWithCors : JsonResultBase
    {
        public JsonActionResultWithCors(HttpRequest request, object model, string corsSettings) : base(request, model)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
        }
    }
}