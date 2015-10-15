namespace ConsoleWebServer.Framework.Json
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using ConsoleWebServer.Framework.Interfaces;
    using Newtonsoft.Json;

    class JsonResult : IJsonResult, IResult
    {
        private readonly object model;

        protected JsonResult(HttpRequest request, object model)
        {
            this.model = model;
            this.Request = request;
            this.ResponseHeaders = new Dictionary<string, string>();
        }

        public HttpRequest Request { get; private set; }

        public Dictionary<string, string> ResponseHeaders { get; private set; }

        public virtual HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.OK;
        }

        public string GetContent()
        {
            return JsonConvert.SerializeObject(this.model);
        }

        public HttpResponse GetResponse()
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
