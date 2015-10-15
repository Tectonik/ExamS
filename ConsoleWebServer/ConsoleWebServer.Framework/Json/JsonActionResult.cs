namespace ConsoleWebServer.Framework
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Newtonsoft.Json;

    public class JsonActionResult : IActionResult
    {
        private readonly object Model;

        public JsonActionResult(HttpRequest request, object model)
        {
            this.Model = model;
            this.Request = request;
            this.ResponseHeaders = new List<KeyValuePair<string, string>>();
        }

        public HttpRequest Request { get; private set; }

        public List<KeyValuePair<string, string>> ResponseHeaders { get; private set; }

        public virtual HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.OK;
        }

        public string GetContent()
        {
            return JsonConvert.SerializeObject(this.Model);
        }

        public HttpResponse GetResponse()
        {
            var response = new HttpResponse(this.Request.ProtocolVersion, this.GetStatusCode(), this.GetContent(), HighQualityCodeExamPointsProvider.GetContentType());
            foreach (KeyValuePair<string, string> responseHeader in this.ResponseHeaders)
            {
                response.AddHeader(responseHeader.Key, responseHeader.Value);
            }
            return response;
        }
    }
}