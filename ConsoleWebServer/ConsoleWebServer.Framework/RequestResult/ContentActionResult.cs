namespace ConsoleWebServer.Framework.RequestResult
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using ConsoleWebServer.Framework;
    using ConsoleWebServer.Framework.ActionResult;

    public class ContentActionResult : HttpRequestResult
    {
        public ContentActionResult(HttpRequest request, object model) : base(request, model)
        {
        }

        public override HttpResponse GetResponse()
        {
            var response = new HttpResponse(this.Request.ProtocolVersion, HttpStatusCode.OK, this.Model.ToString(), "text/plain; charset=utf-8");
            foreach (KeyValuePair<string, string> responseHeader in this.ResponseHeaders)
            {
                response.AddHeader(responseHeader.Key, responseHeader.Value);
            }

            return response;
        }
    }
}