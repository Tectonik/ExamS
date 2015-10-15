﻿namespace ConsoleWebServer.Framework
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using ConsoleWebServer.Framework.Exceptions;

    public class HttpRequest
    {
        public HttpRequest(string method, string uri, string httpVersion)
        {
            this.ProtocolVersion = Version.Parse(httpVersion.ToLower().Replace("HTTP/".ToLower(), string.Empty).Trim());
            this.Headers = new SortedDictionary<string, ICollection<string>>();
            this.Uri = uri;
            this.Method = method;
            this.Action = new ActionDescriptor(uri);
        }

        public Version ProtocolVersion { get; protected set; }

        public IDictionary<string, ICollection<string>> Headers { get; protected set; }

        public string Uri { get; private set; }

        public string Method { get; private set; }

        public ActionDescriptor Action { get; private set; }

        public void AddHeader(string name, string valueValueValue)
        {
            if (!this.Headers.ContainsKey(name))
            {
                this.Headers.Add(name, new HashSet<string>(new List<string>()));
            }

            this.Headers[name].Add(valueValueValue);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(
                string.Format(
                    "{0} {1} {2}{3}",
                    this.Method,
                    this.Action,
                    "HTTP/",
                    this.ProtocolVersion));
            var headerStringBuilder = new StringBuilder();
            foreach (string key in this.Headers.Keys)
            {
                headerStringBuilder.AppendLine(string.Format("{0}: {1}", key, string.Join("; ", this.Headers[key])));
            }

            sb.AppendLine(headerStringBuilder.ToString());
            return sb.ToString();
        }

        public HttpRequest Parse(string reqAsStr)
        {
            var textReader = new StringReader(reqAsStr);
            string firstLine = textReader.ReadLine();
            HttpRequest requestObject = this.CreateRequest(firstLine);

            string line;
            while ((line = textReader.ReadLine()) != null)
            {
                this.AddHeaderToRequest(requestObject, line);
            }

            return requestObject;
        }

        private HttpRequest CreateRequest(string frl)
        {
            string[] firstRequestLineParts = frl.Split(' ');
            if (firstRequestLineParts.Length != 3)
            {
                throw new ParserException(
                    "Invalid format for the first request line. Expected format: [Method] [Uri] HTTP/[Version]");
            }

            var requestObject = new HttpRequest(
                firstRequestLineParts[0],
                firstRequestLineParts[1],
                firstRequestLineParts[2]);

            return requestObject;
        }

        private void AddHeaderToRequest(HttpRequest r, string headerLine)
        {
            string[] hp = headerLine.Split(new[] { ':' }, 2);
            string hn = hp[0].Trim();
            string hv = hp.Length == 2 ? hp[1].Trim() : string.Empty;
            r.AddHeader(hn, hv);
        }
    }
}