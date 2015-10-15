namespace ConsoleWebServer.Framework
{
    using System.Collections.Generic;

    public class JsonActionResultWithCorsWithoutCaching : JsonActionResult
    {
        public JsonActionResultWithCorsWithoutCaching(HttpRequest request, object model, string corsSettings) : base(request, model)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
            this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
        }
    }
}