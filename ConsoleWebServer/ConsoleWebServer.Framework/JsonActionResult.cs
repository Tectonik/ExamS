using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

public class JsonActionResult : IActionResult
{
    public readonly object model;

    public JsonActionResult(HttpRq rq, object m)
    {
        this.model = m;
        this.Request = rq;
        this.ResponseHeaders = new List<KeyValuePair<string, string>>();
    }

    public HttpRq Request { get; private set; }

    public List<KeyValuePair<string, string>> ResponseHeaders { get; private set; }

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
        var response = new HttpResponse(this.Request.ProtocolVersion, this.GetStatusCode(), this.GetContent(), HighQualityCodeExamPointsProvider.GetContentType());
        foreach (KeyValuePair<string, string> responseHeader in this.ResponseHeaders)
        {
            response.AddHeader(responseHeader.Key, responseHeader.Value);
        }
        return response;
    }
}