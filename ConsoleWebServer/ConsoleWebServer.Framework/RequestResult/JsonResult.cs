namespace ConsoleWebServer.Framework.RequestResult
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using ConsoleWebServer.Framework;
    using ConsoleWebServer.Framework.ActionResult;
    using Newtonsoft.Json;

    internal class JsonResult : HttpRequestResult
    {
        protected JsonResult(HttpRequest request, object model) : base(request, model)
        {
        }

        public virtual HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.OK;
        }

        public string GetContent()
        {
            return JsonConvert.SerializeObject(this.model);
        }

        public override HttpResponse GetResponse()
        {
            var response = new HttpResponse(this.Request.ProtocolVersion, this.GetStatusCode(), this.GetContent(), ResponceType.GetContentType());
            foreach (KeyValuePair<string, string> responseHeader in this.ResponseHeaders)
            {
                response.AddHeader(responseHeader.Key, responseHeader.Value);
            }

            return response;
        }
    }
}